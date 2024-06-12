using Super.Interfaces.Patient;

namespace Maladies.Base.SubTypes
{
    public class Adn : IAdn
    {
        public string AdnValue { get; }

        public Adn(string sequence)
        {
            AdnValue = sequence;
        }
    }
}