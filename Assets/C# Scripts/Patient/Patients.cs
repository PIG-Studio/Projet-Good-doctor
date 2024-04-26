using System;
using GameCore.GameVAR;
using Interfaces;
using JetBrains.Annotations;
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

        private static Random rnd = new Random();
        public Patients(Maladie sickness, string adn, bool adNormal, uint depression, uint temperature,
            uint freqCar, string catchPhrase, bool lie /*int mood*/, Sprite skin, 
            string name, Vector2 position) : 
            base(sickness, adn, adNormal, depression, temperature, 
                freqCar, catchPhrase, lie /*mood*/,  skin, name, position)
        {
        }

        private static IMaladie RandMaladie()
        {
            return Acces.Maladies[rnd.Next(0, Acces.Maladies.Length)];
        }
        private static (string,string,uint,uint,uint) PreGenPat(IMaladie maladie)
        { 
            int phraseI = rnd.Next(0, Constantes.PhraseArray.Length);
            string phrase = Constantes.PhraseArray[phraseI];
            int nameI = rnd.Next(0, Constantes.NameArray.Length);
            string name2 = Constantes.NameArray[nameI];
            uint depress = (uint)rnd.Next((int)maladie.Depression.Item1, (int)maladie.Depression.Item2);
            uint temp = (uint)rnd.Next((int)maladie.Temperature.Item1, (int)maladie.Temperature.Item2);
            uint freq = (uint)rnd.Next((int)maladie.FreqCar.Item1, (int)maladie.FreqCar.Item2);
            return (phrase,name2,depress,temp,freq);
        }

        private static string GenAdn(bool adnValid)
        {
            if (adnValid)
            {
                return Constantes.AdnArray[rnd.Next(0, Constantes.AdnArray.Length)];
            }
            else
            {
                return Constantes.AnormalAdnArray[rnd.Next(0, Constantes.AnormalAdnArray.Length)];
            }
        }

        [CanBeNull]
        public static Patient GenPatient()
        {
            if (Variables.NbOfPatients < Constantes.MaxPatient)
            {
                IMaladie maladie;
                int lie = rnd.Next(0, 10);
                if (lie == 0)
                {
                    maladie = Acces.BONNESANTE();
                }
                else
                {
                    maladie = RandMaladie();
                }

                (string phrase, string nameTemp, uint depress, uint temp, uint freq) = PreGenPat(maladie);
                string adn = GenAdn(maladie.NormalAdn);
                Variables.NbOfPatients += 1;
                return new Patient(maladie, adn, maladie.NormalAdn, depress, temp, freq, phrase, lie == 0, null, nameTemp,
                    new Vector2(3, 6));
            }

            return null;
        }
    }
}