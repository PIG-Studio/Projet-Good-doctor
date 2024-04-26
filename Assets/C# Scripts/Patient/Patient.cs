using System;
using Interfaces;
using UnityEngine;

namespace Patient
{
    public class Patient : MonoBehaviour , IPnj , IPatient
    {
        // Creer Patient(S) Genere le random et classe les patients en fct de leur maladie et utilise Patient comme Moule
        public void Spawn()
        {
            Instantiate(Resources.Load<GameObject>("Patient"));
        }
        
        public bool IsLying { get; set; }
        
        // public Maladie Sickness {get;set;}
        
        public int Mood { get; set; }
        
        public string CatchPhrase { get; set; }
        public uint FreqCar { get; set; }
        public uint Temperature { get; set; }
        public string Adn { get; set; }
        public bool ADNormal { get; set; }
        public bool IsAlive { get; set; }
        public void Kill()
        {
            throw new NotImplementedException();
        }

        public Sprite Skin { get; set; }
        
        public string Name { get; set; }
        
        public Vector2 Position { get; set; }

        public Patient(uint temperature ,uint freqCar ,string catchPhrase ,bool lie, int mood, string phrase , Sprite skin , string name , Vector2 position)
        {
            Temperature = temperature;
            FreqCar = freqCar;
            CatchPhrase = catchPhrase;
            IsLying = lie;
            if (Mood < 0 || Mood > 100)
            {
                throw new ArgumentException();
            }
            Mood = mood;
            CatchPhrase = phrase;
            Name = name;
            Skin = skin;
            Position = position; // entrée hôpital
            Spawn();
        }
        public void Talk()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
        
    }
}