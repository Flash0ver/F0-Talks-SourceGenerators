﻿using System.Reflection;

namespace F0.Gen.IsEnumDefined;

internal sealed partial class IsEnumDefinedGenerator
{
    private static readonly AssemblyName _assemblyName = typeof(IsEnumDefinedGenerator).Assembly.GetName();
    private static readonly string _generatedCodeAttribute = $"""global::System.CodeDom.Compiler.GeneratedCodeAttribute("{_assemblyName.Name}", "{_assemblyName.Version}")""";

    private static readonly string _isEnumDefinedAttribute = $$"""
        // <auto-generated/>
        #nullable enable

        namespace Roslyn.Generated;

        [{{_generatedCodeAttribute}}]
        [global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = true)]
        internal sealed class IsEnumDefinedAttribute<TEnum> : global::System.Attribute
            where TEnum : struct, global::System.Enum
        {
        }

        """;
}