using Maladies.Base;
using Maladies.Base.SubTypes;

namespace Maladies.Implementation
{
    public class PresqueMort : Malade
    {
        public PresqueMort() : base("Presque Mort", new TupleValue(3,13),new TupleValue(40,45), false, new TupleValue(40,49))
        { }
    }
}