using Interfaces;

namespace C__Scripts.Maladie
{
    public abstract class Maladie : IMaladie
    {
        public string Name { get; set; }
        public (uint, uint) FreqCar { get; set; }
        public (uint, uint) Temperature { get; set; }
        public bool ADN_Normalc { get; set; }

        public Maladie(string name, (uint, uint) freqcar)
        {
            Name = name;
            FreqCar = freqcar;
            
        }

    }
}