using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using Maladies.Base;

namespace Interfaces.Patient
{
    public interface IPatient
    {
        /// <summary>
        /// Booléens si le patient ment 
        /// </summary>
        public bool IsLying { get; set; }
        
        /// <summary>
        /// Définit la maladie du patient.
        /// </summary>
        public IMaladie Sickness {get;set;}
        
        /*public int Mood { get; set; }*/
        
        /// <summary>
        /// Définit la fréquence cardiaque du patient 
        /// </summary>
        public IValue FreqCar { get; set; }
        
        /// <summary>
        /// Définit la température du patient 
        /// </summary>
        public IValue Temperature { get; set; }
        
        /// <summary>
        /// Définit la depréssion du patient 
        /// </summary>
        public IValue Depression { get; set; }
        
        /// <summary>
        /// Définit l'adn du patient 
        /// </summary>
        public IAdn Adn { get; set; }
        
        /// <summary>
        /// Booléens si le patient est en vie 
        /// </summary>
        public bool IsAlive { get; set; }
        
        /// <summary>
        /// Booléens si l'adn du patient a été analysé
        /// </summary>
        public bool AnalyseAdn { get; set; }
        
        /// <summary>
        /// Booléens si la dépression du patient a été analysé
        /// </summary>
        public bool AnalyseDepression { get; set; }
        

        /// <summary>
        /// Quand finit de s'occuper du patient va jusqu'à la sortie
        /// </summary>
        public void LeaveServerRpc();

        
        
        /// <summary>
        /// quand patient est mort , change son skin , enable la fct de bouger son corps , et lance un timer pour degager son corps
        /// </summary>
        public void Kill();
    }
}