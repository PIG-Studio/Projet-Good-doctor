using GameCore.Constantes;
using Super.Interfaces.Maladies;
using Super.Interfaces.Maladies.Types;
using Super.Interfaces.Patient;
using Maladies.Base.SubTypes;
using Maladies.Base.SubTypes.Symptomes;
using TypeExpand.Int;
using TypeExpand.Value;

namespace Patient.Base
{
    public static class Attributs
    {
        // Méthodes pour générer aléatoirement des phrases, des noms et des valeurs de dépression, température et fréquence cardiaque
        private static string PhraseRandom => Constante.PhraseArray[Constante.PhraseArray.Length.RandomInt()];
        private static string NameRandom => Constante.NameArray[Constante.NameArray.Length.RandomInt()];
        private static IValue DepressRandom(IMaladie maladie) => new Value(maladie.Depression.RandomUint());
        private static IValue TempRandom(IMaladie maladie) => new Value(maladie.Temperature.RandomUint());
        private static IValue FreqRandom(IMaladie maladie) => new Value(maladie.FreqCar.RandomUint());

        /// <summary>
        /// Méthode pour générer aléatoirement un ensemble de phrases, nom, dépression, température et fréquence cardiaque
        /// </summary>
        /// <param name="maladie"></param>
        /// <returns></returns>
        public static (string phrase, string name, IValue depress, IValue temperature, IValue freq) Generer(IMaladie maladie)
        { 
            return (PhraseRandom,NameRandom,DepressRandom(maladie),TempRandom(maladie),FreqRandom(maladie));
        }
        
        /// <summary>
        /// Méthode pour générer aléatoirement un objet ADN valide ou anormal
        /// </summary>
        /// <param name="adnValid"></param>
        /// <returns></returns>
        public static IAdn GenAdn(bool adnValid)
        {
            return adnValid ? new Adn(Constante.AdnArray[Constante.AdnArray.Length.RandomInt()]) : new Adn(Constante.AnormalAdnArray[Constante.AnormalAdnArray.Length.RandomInt()]);
        }
    }
}