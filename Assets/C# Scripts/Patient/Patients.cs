using System;
using GameCore.GameVAR;
using Interfaces;
using Maladies;
using Maladies.Base;
using UnityEngine;
using Random = System.Random;
using Maladies;
namespace Patient
{
    using static Random;

    public class Patients : Patient
    {
        // choisis aleatoire maladie , mensonge ou non , pour plus tard Skin/Nom/Catchphrase
        //choisis en randint dans maladie.array[maladies] 
        //si pas atteint le nombre max de porteur de maladie alors on creer sinon on rerandint
        //On Creer (ADN , temp , freq , mood , depression , ADNormale ) en fct des symptomes la maladie (randint des intervalles)
        // on random lying , catchphrase
        
        public Patients(Maladie sickness, string adn, bool adNormal, uint depression, uint temperature,
            uint freqCar, string catchPhrase, bool lie /*int mood*/, Sprite skin, 
            string name, Vector2 position) : 
            base(sickness, adn, adNormal, depression, temperature, 
                freqCar, catchPhrase, lie /*mood*/,  skin, name, position)
        {
        }
        
        public static Patient GenPat()
        {
            if (Variables.NbOfPatients < Constantes.MaxPatient)
            {
                Random rnd = new Random();
                int lie = rnd.Next(0, 1);
                bool lies = lie == 1;
                if (lies == false)
                {
                    // Cas ou le patient ment sur sa maladie , alors il n'est pas malade
                    // on va juste creer un patient avec une maladie mais des signes vitaux normaux aleatoire
                    int sickI = rnd.Next(0, Acces.Maladies.Length - 1);
                    IMaladie sick = Acces.Maladies[sickI];
                    int adnI = rnd.Next(0, Constantes.AdnArray.Length - 1);
                    string adn = Constantes.AdnArray[adnI];
                    int phraseI = rnd.Next(0, Constantes.PhraseArray.Length - 1);
                    string phrase = Constantes.PhraseArray[phraseI];
                    int nameI = rnd.Next(0, Constantes.NameArray.Length - 1);
                    string name2 = Constantes.NameArray[nameI];
                    uint depress = (uint)rnd.Next(0, 9);
                    uint temp = (uint)rnd.Next(35, 37);
                    uint freq = (uint)rnd.Next(60, 80);
                    Variables.NbOfPatients += 1;
                    return new Patient(sick, adn, true, depress, temp, freq, phrase,
                        false, null, name2, new Vector2(0, 0));
                }
                else
                {
                    int sickI = rnd.Next(0, Acces.Maladies.Length - 1);
                    IMaladie sick = Acces.Maladies[sickI];
                    int phraseI = rnd.Next(0, Constantes.PhraseArray.Length - 1);
                    string phrase = Constantes.PhraseArray[phraseI];
                    int nameI = rnd.Next(0, Constantes.NameArray.Length - 1);
                    string name2 = Constantes.NameArray[nameI];
                    uint depress = (uint)rnd.Next((int)sick.Depression.Item1, (int)sick.Depression.Item2);
                    uint temp = (uint)rnd.Next((int)sick.Temperature.Item1, (int)sick.Temperature.Item2);
                    uint freq = (uint)rnd.Next((int)sick.FreqCar.Item1, (int)sick.FreqCar.Item2);
                    if (sick.NormalAdn == false)
                    {
                        int adnI = rnd.Next(0, Constantes.AnormalAdnArray.Length - 1);
                        string adn = Constantes.AnormalAdnArray[adnI];
                        Variables.NbOfPatients += 1;
                        return new Patient(sick, adn, sick.NormalAdn, depress, temp, freq, phrase,
                            false, null, name2, new Vector2(0, 0));

                    }
                    else
                    {
                        int adnI = rnd.Next(0, Constantes.AdnArray.Length - 1);
                        string adn = Constantes.AdnArray[adnI];
                        Variables.NbOfPatients += 1;
                        return new Patient(sick, adn, sick.NormalAdn, depress, temp, freq, phrase,
                            false, null, name2, new Vector2(0, 0));

                    }
                }
            }

            return null;
        }   
    }
}