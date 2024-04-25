﻿using Interfaces;

namespace C__Scripts.Maladie
{
    public abstract class Maladie : IMaladie
    {
        public string Name { get; set; }
        public (uint, uint) FreqCar { get; set; }
        public (uint, uint) Temperature { get; set; }
        public bool NormalAdn { get; set; }

        public (uint, uint) Depression { get; set; }// plus c'est bas plus il est heureux


        
        public Maladie(string name, (uint, uint) freqcar, (uint,uint) temp, bool normalADN, (uint, uint) depression)
        {
            Name = name;
            FreqCar = freqcar;
            Temperature = temp;
            NormalAdn = normalADN;
            Depression = depression;
        }

    }
}