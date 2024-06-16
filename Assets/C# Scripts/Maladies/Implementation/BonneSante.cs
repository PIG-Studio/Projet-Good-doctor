using System;
using System.Linq;
using Maladies.Base;
using GameCore.Constantes;

namespace Maladies.Implementation
{
    public class BonneSante : Sain
    {
        public BonneSante() : base("En Bonne Santé") { }

        public bool EstEnBonneSante(PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient Test)
        {
            return (FreqCar == Test.Adn) && (Temperature == Test.Temperature) &&
                   (Depression == Test.Depression);
        }
    }
}