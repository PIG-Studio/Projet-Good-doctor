using Maladies.Base;
using Maladies.Base.SubTypes;

namespace Maladies.Implementation
{
    public class SyndromePorcelaine : Malade
    {
        public SyndromePorcelaine() : base("Syndrome de Porcelaine", temperature:new TupleValue(32,34), depression:new TupleValue(10,19))
        { }
    }
}