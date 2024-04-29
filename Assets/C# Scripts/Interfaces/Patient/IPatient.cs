using Interfaces.Maladies.Types;
using Maladies.Base;
using UnityEngine.UIElements.Experimental;

namespace Interfaces.Patient
{
    public interface IPatient
    {
        public bool IsLying { get; set; }
        
        public Maladie Sickness {get;set;}
        
        /*public int Mood { get; set; }*/
        
        public string CatchPhrase { get; set; }
        
        public IValue FreqCar { get; set; }
        
        public IValue Temperature { get; set; }
        
        public IValue Depression { get; set; }
        
        public IAdn Adn { get; set; }
        
        public bool AdnSain { get; set; }
        
        public bool IsAlive { get; set; }
        
        public bool AnalyseADN { get; set; }
        
        public bool AnalyseDepression { get; set; }
        

        /// <summary>
        /// Quand finit de s'occuper du patient va jusqu'à la sortie
        /// </summary>
        public void Leave();

        
        
        /// <summary>
        /// quand patient est mort , change son skin , enable la fct de bouger son corps , et lance un timer pour degager son corps
        /// </summary>
        public void Kill();
    }
}