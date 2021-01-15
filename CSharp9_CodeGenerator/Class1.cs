using Microsoft.CodeAnalysis;
using System;

namespace CSharp9_CodeGenerator
{
    [Generator]
    public class Generator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var source = @"class Foo {public string Bar=""bar"";}";
            context.AddSource("Gen.cs", source);
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
