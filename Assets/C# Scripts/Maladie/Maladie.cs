using Interfaces;

namespace C__Scripts.Maladie
{
    public abstract class Maladie : IMaladie
    {
        public string Name { get; set; }
        public (uint, uint) FreqCar { get; set; }
        public (uint, uint) Temperature { get; set; }
        public bool NormalADN { get; set; }
        
        public (uint, uint) Depression { get; set; }

        public Maladie(string name, (uint, uint) freqcar, (uint,uint) temp, bool normalADN, (uint, uint) depression)
        {
            Name = name;
            FreqCar = freqcar;
            Temperature = temp;
            NormalADN = normalADN;
            Depression = depression;
        }

    }
}