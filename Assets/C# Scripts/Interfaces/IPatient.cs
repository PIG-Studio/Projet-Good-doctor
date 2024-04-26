using UnityEngine;

namespace C__Scripts.Interfaces
{
    public interface IPatient
    {
        public bool Is_lying { get; set; }
        
        public Maladie.Maladie Sickness {get;set;}
        
        /*public int Mood { get; set; }*/
        
        public string CatchPhrase { get; set; }
        
        public uint FreqCar { get; set; }
        
        public uint Temperature { get; set; }
        
        public string ADN { get; set; }
        
        public bool ADNormal { get; set; }
        
        public bool IsAlive { get; set; }

        public void Kill();// quand patient est mort , change son skin , enable la fct de bouger son corps , et lance 
        // un timer pour degager son corps
    }
}