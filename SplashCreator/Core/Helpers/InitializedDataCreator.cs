using System;
using System.Collections.Generic;    
using dnlib.DotNet;         

namespace SplashCreator.Core.Helpers
{
    // From https://github.com/0xd4d/de4dot/blob/master/de4dot.code/deobfuscators/InitializedDataCreator.cs	

    public class InitializedDataCreator
    {
        private readonly ModuleDef _module;
        private readonly Dictionary<long, TypeDef> _arrayTypeDictionary;

        private MemberRefUser _initializeArrayMethod;
        private TypeDef _ourType;
        private int _unique;

        public InitializedDataCreator(ModuleDef module)
        {
            _module = module;
            _arrayTypeDictionary = new Dictionary<long, TypeDef>();
        }

        private void CreateOurType()
        {
            if (_ourType != null)
                return;

            _ourType = new TypeDefUser("", $"<PrivateImplementationDetails>{GetModuleId()}",
                _module.CorLibTypes.Object.TypeDefOrRef);
            _ourType.Attributes = TypeAttributes.NotPublic | TypeAttributes.AutoLayout |
                                  TypeAttributes.Class | TypeAttributes.AnsiClass;
            _module.UpdateRowId(_ourType);
            _module.Types.Add(_ourType);
        }

        private object GetModuleId()
        {
            return Guid.NewGuid().ToString("B");
        }

        private TypeDef GetArrayType(long size)
        {
            CreateOurType();

            TypeDef arrayType;
            if (_arrayTypeDictionary.TryGetValue(size, out arrayType))
                return arrayType;

            var importer = new Importer(_module);
            var valueTypeRef = importer.Import(typeof (ValueType));

            arrayType = new TypeDefUser("", $"__StaticArrayInitTypeSize={size}", valueTypeRef);
            _module.UpdateRowId(arrayType);
            arrayType.Attributes = TypeAttributes.NestedPrivate | TypeAttributes.ExplicitLayout |
                                   TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.AnsiClass;
            _ourType.NestedTypes.Add(arrayType);
            _arrayTypeDictionary[size] = arrayType;
            arrayType.ClassLayout = new ClassLayoutUser(1, (uint) size);
            return arrayType;
        }

        public FieldDef Create(byte[] data)
        {
            var arrayType = GetArrayType(data.LongLength);
            var fieldSig = new FieldSig(new ValueTypeSig(arrayType));
            var attrs = FieldAttributes.Assembly | FieldAttributes.Static;
            var field = new FieldDefUser($"field_{_unique++}", fieldSig, attrs);
            _module.UpdateRowId(field);
            field.HasFieldRVA = true;
            _ourType.Fields.Add(field);
            var iv = new byte[data.Length];
            Array.Copy(data, iv, data.Length);
            field.InitialValue = iv;
            return field;
        }

        public TypeDefOrRefSig FindOrCreateTypeRef(ModuleDef module, AssemblyRef asmRef, string ns, string name, bool isValueType)
        {
            var typeRef = module.UpdateRowId(new TypeRefUser(module, ns, name, asmRef));
            if (isValueType)
                return new ValueTypeSig(typeRef);
            
            return new ClassSig(typeRef);
        }

        public MemberRef CreateInitializeArrayMethod()
        {
            if (_initializeArrayMethod == null)
            {
                var runtimeHelpersType = FindOrCreateTypeRef(_module, _module.CorLibTypes.AssemblyRef, "System.Runtime.CompilerServices", "RuntimeHelpers", false);
                var systemArrayType = FindOrCreateTypeRef(_module, _module.CorLibTypes.AssemblyRef, "System", "Array", false);
                var runtimeFieldHandleType = FindOrCreateTypeRef(_module, _module.CorLibTypes.AssemblyRef, "System", "RuntimeFieldHandle", true);
                var methodSig = MethodSig.CreateStatic(_module.CorLibTypes.Void, systemArrayType, runtimeFieldHandleType);
                _initializeArrayMethod = _module.UpdateRowId(new MemberRefUser(_module, "InitializeArray", methodSig, runtimeHelpersType.TypeDefOrRef));
            }
            return _initializeArrayMethod;
        }
    }
}