using Super.Interfaces.Patient;

namespace Maladies.Base.SubTypes
{
    public class Adn : IAdn
    {
        public string AdnValue { get; }
        public bool IsHealthy { get; set; }
        public Adn(string sequence, bool isV)
        {
            AdnValue = sequence;
            IsHealthy = isV;
        }
    }
}