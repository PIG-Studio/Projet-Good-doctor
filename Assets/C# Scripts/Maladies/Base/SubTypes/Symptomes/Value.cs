using Super.Interfaces.Maladies.Types;

namespace Maladies.Base.SubTypes.Symptomes
{
    public class Value : IValue
    {
        public uint Valeur { get; set; }

        public Value(uint input)
        {
            Valeur = input;
        }
    }
}