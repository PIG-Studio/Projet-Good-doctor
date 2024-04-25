using C__Scripts.Maladie;
using UnityEngine;
using Random = System.Random;

namespace C__Scripts.Patient
{
    using static Random;

    public class Patients : PNJ.Patient
    {
        // choisis aleatoire maladie , mensonge ou non , pour plus tard Skin/Nom/Catchphrase
        //choisis en randint dans maladie.array[maladies] 
        //si pas atteint le nombre max de porteur de maladie alors on creer sinon on rerandint
        //On Creer (ADN , temp , freq , mood , depression , ADNormale ) en fct des symptomes la maladie (randint des intervalles)
        // on random lying , catchphrase
        
        public Patients(Maladie.Maladie sickness, string adn, bool adNormal, uint depression, uint temperature, uint freqCar, string catchPhrase, bool lie, int mood, string phrase, Sprite skin, string name, Vector2 position) : base(sickness, adn, adNormal, depression, temperature, freqCar, catchPhrase, lie, mood, phrase, skin, name, position)
        {
        }

        public PNJ.Patient GenPat()
        {
            Random rnd = new Random();
            int lie = rnd.Next(0,1);
            bool lies = lie == 1;
            if (lies == false)
            {
                
            }
            else
            {
                int i = rnd.Next(0, Maladie.Maladies.Maladiess.Length - 1);
            }
        }
    }
}