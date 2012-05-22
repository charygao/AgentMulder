using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using AgentMulder.Containers.CastleWindsor.Patterns.FromTypes;
using AgentMulder.ReSharper.Domain.Patterns;
using AgentMulder.ReSharper.Domain.Registrations;

namespace AgentMulder.Containers.CastleWindsor.Providers
{
    [Export]
    [Export(typeof(IRegistrationPatternsProvider))]
    public class AllTypesRegistrationProvider : IRegistrationPatternsProvider
    {
        private const string AllTypesFullTypeName = "Castle.MicroKernel.Registration.AllTypes";

        private readonly BasedOnRegistrationProvider basedOnProvider;

        [ImportingConstructor]
        public AllTypesRegistrationProvider(BasedOnRegistrationProvider basedOnProvider)
        {
            this.basedOnProvider = basedOnProvider;
        }

        public IEnumerable<IRegistrationPattern> GetRegistrationPatterns()
        {
            var basedOnPatterns = basedOnProvider.GetRegistrationPatterns().ToArray();

            return new IRegistrationPattern[]
            {
                new From(AllTypesFullTypeName, ClassesRegistrationProvider.Filter, basedOnPatterns),
                new FromAssembly(AllTypesFullTypeName, ClassesRegistrationProvider.Filter, basedOnPatterns), 
                new FromThisAssembly(AllTypesFullTypeName, ClassesRegistrationProvider.Filter, basedOnPatterns),
                new FromAssemblyNamed(AllTypesFullTypeName, ClassesRegistrationProvider.Filter, basedOnPatterns), 
                new FromAssemblyContainingGeneric(AllTypesFullTypeName, ClassesRegistrationProvider.Filter, basedOnPatterns),
                new FromAssemblyContainingNonGeneric(AllTypesFullTypeName, ClassesRegistrationProvider.Filter, basedOnPatterns)
            };
        }
    }
}