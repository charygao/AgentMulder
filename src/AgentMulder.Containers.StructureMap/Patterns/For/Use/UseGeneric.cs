﻿using System.ComponentModel.Composition;
using AgentMulder.ReSharper.Domain.Patterns;
#if SDK90
using JetBrains.ReSharper.Feature.Services.CSharp.StructuralSearch;
using JetBrains.ReSharper.Feature.Services.CSharp.StructuralSearch.Placeholders;
using JetBrains.ReSharper.Feature.Services.StructuralSearch;
#else
using JetBrains.ReSharper.Psi.Services.CSharp.StructuralSearch;
using JetBrains.ReSharper.Psi.Services.CSharp.StructuralSearch.Placeholders;
using JetBrains.ReSharper.Psi.Services.StructuralSearch;
#endif

namespace AgentMulder.Containers.StructureMap.Patterns.For.Use
{
    [Export(typeof(ComponentImplementationPatternBase))]
    internal sealed class UseGeneric : ComponentImplementationPatternBase
    {
        private static readonly IStructuralSearchPattern pattern = 
            new CSharpStructuralSearchPattern("$createExpr$.Use<$type$>()",
                new ExpressionPlaceholder("createExpr", "global::StructureMap.Configuration.DSL.Expressions.CreatePluginFamilyExpression<...>"),
                new TypePlaceholder("type"));

        public UseGeneric()
            : base(pattern, "type")
        {
        }
    }
}