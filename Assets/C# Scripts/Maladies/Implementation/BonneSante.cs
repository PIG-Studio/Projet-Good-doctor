using Maladies.Base;
using Super.Interfaces.Patient;

namespace Maladies.Implementation
{
    public class BonneSante : Sain
    {
        public BonneSante() : base("En Bonne Santé") { }

        public bool EstEnBonneSante(IPatient patientTest)
        {
            return (FreqCar == patientTest.FreqCar) && (Temperature == patientTest.Temperature) &&
                   (Depression == patientTest.Depression);
        }
    }
}