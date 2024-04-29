using System;
using Interfaces;
using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using Interfaces.Patient;
using UnityEngine;
using Maladies.Base;
using IPnj = Interfaces.IPnj;

namespace Patient
{
    public class Patient : MonoBehaviour , IPnj , IPatient
    {
        // Creer Patient(S) Genere le random et classe les patients en fct de leur maladie et utilise Patient comme Moule
        /// <summary>
        /// Instantie un patient a l'entrée de l'hôpital
        /// </summary>
        public void Spawn()
        {
            Instantiate(Resources.Load<GameObject>("Patient")).name = Name ;
        }
        
        public bool IsLying { get; set; }
        
        public Maladie Sickness {get;set;}
        
        /*public int Mood { get; set; }*/
        
        public string CatchPhrase { get; set; }
        public IValue FreqCar { get; set; }
        public IValue Temperature { get; set; }
        public IAdn Adn { get; set; }
        public bool AdnSain { get; set; }
        public bool IsAlive { get; set; }
        public IValue Depression { get; set; }
        public Sprite Skin { get; set; }
        
        public string Name { get; set; }
        
        public Vector2 Position { get; set; }

        public Patient(IMaladie sickness ,IAdn adn, bool adNormal , IValue depression, IValue temperature ,
            IValue freqCar ,string catchPhrase ,bool lie /*int mood*/, Sprite skin , string name , Vector2 position)
        {
            /*
            if (Mood < 0 || Mood > 100)
            {
                throw new ArgumentException();
            }
            */
            if (sickness is Maladie)
            {
                Sickness = (Maladie)sickness;
            }
            Depression = depression;
            IsAlive = true;
            AdnSain = adNormal;
            Adn = adn;
            Temperature = temperature;
            FreqCar = freqCar;
            CatchPhrase = catchPhrase;
            IsLying = lie;
            //Mood = mood;
            Name = name;
            Skin = skin;
            Position = position; // entrée hôpital
            Spawn();
        }
        public void Talk()
        {
            throw new NotImplementedException();
        }
        public void Leave()
        {
            throw new NotImplementedException();
        }

        public void Kill()
        {
            throw new NotImplementedException();
        }
        
        public void Move()
        {
            throw new NotImplementedException();
        }


    }
}