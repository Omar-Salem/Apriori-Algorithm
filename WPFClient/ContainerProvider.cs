using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using AprioriAlgorithm;

namespace WPFClient
{
    internal static class ContainerProvider
    {
        private static CompositionContainer container;

        public static CompositionContainer Container
        {
            get
            {
                if (container == null)
                {
                    List<AssemblyCatalog> catalogList = new List<AssemblyCatalog>();
                    catalogList.Add(new AssemblyCatalog(typeof(IApriori).Assembly));
                    catalogList.Add(new AssemblyCatalog(typeof(IResult).Assembly));
                    container = new CompositionContainer(new AggregateCatalog(catalogList));
                }

                return container;
            }
        }
    }
}
