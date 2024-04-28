using Interfaces.Maladies.Symptomes;

namespace GameCore.TypeExpand.Value
{
    public static class Mortel
    {
        public static bool Mortelle(IValue freqCarPatient)
        {
            return !freqCarPatient.Value.EstEntre(10, 150);
        }
        
    }
}