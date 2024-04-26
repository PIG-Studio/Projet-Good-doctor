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
        
        public Patients(Maladie.Maladie sickness, string adn, bool adNormal, uint depression, uint temperature,
            uint freqCar, string catchPhrase, bool lie /*int mood*/, Sprite skin, 
            string name, Vector2 position) : 
            base(sickness, adn, adNormal, depression, temperature, 
                freqCar, catchPhrase, lie /*mood*/,  skin, name, position)
        {
        }

        public PNJ.Patient GenPat()
        {
            Random rnd = new Random();
            int lie = rnd.Next(0,1);
            bool lies = lie == 1;
            if (lies == false)
            {
                // Cas ou le patient ment sur sa maladie , alors il n'est pas malade
                // on va juste creer un patient avec une maladie mais des signes vitaux normaux aleatoire
                int sickI = rnd.Next(0, Maladie.Maladies.Maladiess.Length - 1);
                Maladie.Maladie sick = Maladies.Maladiess[sickI];
                int adnI = rnd.Next(0, GameCore.Constantes.AdnArray.Length - 1);
                string adn = GameCore.Constantes.AdnArray[adnI];
                int phraseI = rnd.Next(0, GameCore.Constantes.PhraseArray.Length - 1);
                string phrase = GameCore.Constantes.PhraseArray[phraseI];
                int nameI = rnd.Next(0, GameCore.Constantes.NameArray.Length - 1);
                string name2 = GameCore.Constantes.NameArray[nameI];
                uint depress = (uint)rnd.Next(0, 9);
                uint temp = (uint)rnd.Next(35, 37);
                uint freq = (uint)rnd.Next(60, 80);
                return new PNJ.Patient(sick, adn, true, depress, temp, freq, phrase,
                    false, null, name2, new Vector2(0,0));
            }
            else
            {
                int sickI = rnd.Next(0, Maladie.Maladies.Maladiess.Length - 1);
                Maladie.Maladie sick = Maladies.Maladiess[sickI];
                int phraseI = rnd.Next(0, GameCore.Constantes.PhraseArray.Length - 1);
                string phrase = GameCore.Constantes.PhraseArray[phraseI];
                int nameI = rnd.Next(0, GameCore.Constantes.NameArray.Length - 1);
                string name2 = GameCore.Constantes.NameArray[nameI];
                uint depress = (uint)rnd.Next((int)sick.Depression.Item1, (int)sick.Depression.Item2);
                uint temp = (uint)rnd.Next((int)sick.Temperature.Item1, (int)sick.Temperature.Item2);
                uint freq = (uint)rnd.Next((int)sick.FreqCar.Item1, (int)sick.FreqCar.Item2);
                if (sick.NormalADN == false) 
                {
                    int adnI = rnd.Next(0, GameCore.Constantes.AnormalAdnArray.Length - 1);
                    string adn = GameCore.Constantes.AnormalAdnArray[adnI];
                    return new PNJ.Patient(sick, adn, sick.NormalADN, depress, temp, freq, phrase,
                        false, null, name2, new Vector2(0,0));

                }
                else
                {
                    int adnI = rnd.Next(0, GameCore.Constantes.AdnArray.Length - 1);
                    string adn = GameCore.Constantes.AdnArray[adnI];
                    return new PNJ.Patient(sick, adn, sick.NormalADN, depress, temp, freq, phrase,
                        false, null, name2, new Vector2(0,0));

                }
                
            }
        }   
    }
}