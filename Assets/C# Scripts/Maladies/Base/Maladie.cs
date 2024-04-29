using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using JetBrains.Annotations;
using Maladies.Base.SubTypes;

namespace Maladies.Base
{
    public abstract class Maladie : IMaladie
    {
        public string Name { get; }
        public ITupleValue FreqCar { get; }
        public ITupleValue Temperature { get; }
        public bool AdnSain { get; }
        
        public ITupleValue Depression { get; }

        
        public Maladie(string name, [CanBeNull] ITupleValue freqcar = null, [CanBeNull] ITupleValue temperature = null, bool adnSain = true, [CanBeNull] ITupleValue depression = null)
        {
            Name = name;
            FreqCar = freqcar ?? new TupleValue(60u, 80u);
            Temperature = temperature ?? new TupleValue(35u, 37u);
            AdnSain = adnSain;
            Depression = depression ?? new TupleValue(0u, 2u);
        }

    }
}