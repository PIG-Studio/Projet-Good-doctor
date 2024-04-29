using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using JetBrains.Annotations;
using Maladies.Base.SubTypes;

namespace Maladies.Base
{
    public abstract class Sain : IMaladie
    {
        public string Name { get; }
        public ITupleValue FreqCar { get; }
        public ITupleValue Temperature { get; }
        public bool AdnSain { get; }
        
        public ITupleValue Depression { get; }
        
        public Sain([CanBeNull] string name)
        {
            Name = name ?? "Sain";
            FreqCar = new TupleValue(60u, 80u);
            Temperature = new TupleValue(35u, 37u);
            AdnSain = true;
            Depression = new TupleValue(0u, 2u);
        }
        
    }
}