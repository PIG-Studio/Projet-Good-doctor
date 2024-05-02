using GameCore.GameVAR;
using TypeExpand.Int;
using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using Interfaces.Patient;
using JetBrains.Annotations;
using Maladies;
using Maladies.Base.SubTypes;
using UnityEngine;
using Maladies.Base.SubTypes.Symptomes;
using TypeExpand.Value;

namespace Patient
{
    public class Patients : MonoBehaviour
    {
        // choisis aleatoire maladie , mensonge ou non , pour plus tard Skin/Nom/Catchphrase
        //choisis en randint dans maladie.array[maladies] 
        //si pas atteint le nombre max de porteur de maladie alors on creer sinon on rerandint
        //On Creer (ADN , temp , freq , mood , depression , ADNormale ) en fct des symptomes la maladie (randint des intervalles)
        // on random lying , catchphrase

        /*public Patients(Maladie sickness, string adn, bool adNormal, uint depression, uint temperature,
            uint freqCar, string catchPhrase, bool lie /*int mood, Sprite skin, 
            string name, Vector2 position) : 
            base(sickness, adn, adNormal, depression, temperature, 
                freqCar, catchPhrase, lie /*mood,  skin, name, position)
        {
        }*/

        private static IMaladie RandMaladie()
        {
            return Acces.Maladies[Acces.Maladies.Length.RandomInt()];
        }
        private static (string,string, IValue, IValue, IValue) PreGenPat(IMaladie maladie)
        { 
            int phraseI = Constantes.PhraseArray.Length.RandomInt();
            string phrase = Constantes.PhraseArray[phraseI];
            int nameI = Constantes.NameArray.Length.RandomInt();
            string name2 = Constantes.NameArray[nameI];
            
            IValue depress = new Value(maladie.Depression.RandomUint());
            IValue temp = new Value(maladie.Temperature.RandomUint());
            IValue freq = new Value(maladie.FreqCar.RandomUint());
            
            return (phrase,name2,depress,temp,freq);
        }

        private static IAdn GenAdn(bool adnValid)
        {
            if (adnValid)
            {
                return new Adn(Constantes.AdnArray[Constantes.AdnArray.Length.RandomInt()]);
            }
            return new Adn(Constantes.AnormalAdnArray[Constantes.AnormalAdnArray.Length.RandomInt()]);
            
        }

        [CanBeNull]
        public static Patient GenPatient()
        {
            if (Variables.NbOfPatients < Constantes.MaxPatient)
            {
                IMaladie maladie;
                int lie = 10.RandomInt();
                if (lie == 0)
                {
                    maladie = Acces.BONNESANTE();
                }
                else
                {
                    maladie = RandMaladie();
                }

                (string phrase, string nameTemp, IValue depress,IValue temp, IValue freq) = PreGenPat(maladie);
                IAdn adn = GenAdn(maladie.AdnSain);
                Variables.NbOfPatients += 1;
                return new Patient(maladie, adn, maladie.AdnSain, depress, temp, freq, phrase, lie == 0, null, nameTemp,
                    new Vector2(3, 6));
            }

            return null;
        }
    }
}