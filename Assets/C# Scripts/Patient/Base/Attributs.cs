using GameCore.Constantes;
using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using Interfaces.Patient;
using Maladies.Base.SubTypes;
using Maladies.Base.SubTypes.Symptomes;
using TypeExpand.Int;
using TypeExpand.Value;

namespace Patient.Base
{
    public static class Attributs
    {
        private static string PhraseRandom => Constante.PhraseArray[Constante.PhraseArray.Length.RandomInt()];
        private static string NameRandom => Constante.NameArray[Constante.NameArray.Length.RandomInt()];
        private static IValue DepressRandom(IMaladie maladie) => new Value(maladie.Depression.RandomUint());
        private static IValue TempRandom(IMaladie maladie) => new Value(maladie.Temperature.RandomUint());
        private static IValue FreqRandom(IMaladie maladie) => new Value(maladie.FreqCar.RandomUint());

        public static (string phrase, string name, IValue depress, IValue temperature, IValue freq) Generer(IMaladie maladie)
        { 
            return (PhraseRandom,NameRandom,DepressRandom(maladie),TempRandom(maladie),FreqRandom(maladie));
        }
        
        public static IAdn GenAdn(bool adnValid)
        {
            return adnValid ? new Adn(Constante.AdnArray[Constante.AdnArray.Length.RandomInt()]) : new Adn(Constante.AnormalAdnArray[Constante.AnormalAdnArray.Length.RandomInt()]);
        }
    }
}