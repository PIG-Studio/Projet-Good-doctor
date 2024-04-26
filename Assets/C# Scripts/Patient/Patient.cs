using System;
using System.ComponentModel;
using C__Scripts.Interfaces;
using UnityEngine;

namespace C__Scripts.PNJ
{
    public class Patient : MonoBehaviour , Ipnj , IPatient
    {
        // Creer Patient(S) Genere le random et classe les patients en fct de leur maladie et utilise Patient comme Moule
        public void Spawn()
        {
            Instantiate(Resources.Load<GameObject>("Patient"));
        }
        
        public bool Is_lying { get; set; }
        
        public Maladie.Maladie Sickness {get;set;}
        
        /*public int Mood { get; set; }*/
        
        public string CatchPhrase { get; set; }
        public uint FreqCar { get; set; }
        public uint Temperature { get; set; }
        public string ADN { get; set; }
        public bool ADNormal { get; set; }
        public bool IsAlive { get; set; }
        public uint Depression { get; set; }
        public void Leave()
        {
            throw new NotImplementedException();
        }

        public void Kill()
        {
            throw new NotImplementedException();
        }

        public Sprite Skin { get; set; }
        
        public string Name { get; set; }
        
        public Vector2 Position { get; set; }
        public void Move()
        {
            throw new NotImplementedException();
        }

        public Patient(Maladie.Maladie sickness ,string adn, bool adNormal , uint depression, uint temperature ,
            uint freqCar ,string catchPhrase ,bool lie /*int mood*/, Sprite skin , string name , Vector2 position)
        {
            /*
            if (Mood < 0 || Mood > 100)
            {
                throw new ArgumentException();
            }
            */
            
            Sickness = sickness;
            Depression = depression;
            IsAlive = true;
            ADNormal = adNormal;
            ADN = adn;
            Temperature = temperature;
            FreqCar = freqCar;
            CatchPhrase = catchPhrase;
            Is_lying = lie;
            /*Mood = mood;*/
            Name = name;
            Skin = skin;
            Position = position; // entrée hôpital
            Spawn();
        }
        public void Talk()
        {
            
        }
    }
}