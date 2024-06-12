using Super.Interfaces.Maladies.Types;

namespace Super.Interfaces.Maladies
{
    public interface IMaladie
    {
        /// <summary>
        /// Le nom de la maladie 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// La fréquence cardiaque associée à la maladie.
        /// </summary>
        ITupleValue FreqCar { get; }
        
        /// <summary>
        /// La température corporelle associée à la maladie.
        /// </summary>
        ITupleValue Temperature { get; }
        
        /// <summary>
        /// Indique si l'ADN est sain.
        /// </summary>
        bool AdnSain { get;  }
        
        /// <summary>
        /// Le niveau de dépression associé à la maladie.
        /// </summary>
        ITupleValue Depression { get; }
    }
}