using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using JetBrains.Annotations;
using Maladies.Base.SubTypes;

namespace Maladies.Base
{
    public abstract class Malade : IMaladie
    {
        /// <summary>
        /// Le nom du malade 
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///  Fréquence cardiaque du malade
        /// </summary>
        public ITupleValue FreqCar { get; }
        /// <summary>
        /// Sa température
        /// </summary>
        public ITupleValue Temperature { get; }
        /// <summary>
        /// Son adn sain
        /// </summary>
        public bool AdnSain { get; }
        /// <summary>
        /// Sa dépression
        /// </summary>
        public ITupleValue Depression { get; }

        
        public Malade(string name, [CanBeNull] ITupleValue freqcar = null, [CanBeNull] ITupleValue temperature = null, bool adnSain = true, [CanBeNull] ITupleValue depression = null)
        {
            Name = name;
            FreqCar = freqcar ?? new TupleValue(60u, 80u);
            Temperature = temperature ?? new TupleValue(35u, 37u);
            AdnSain = adnSain;
            Depression = depression ?? new TupleValue(0u, 2u);
        }
    }
}