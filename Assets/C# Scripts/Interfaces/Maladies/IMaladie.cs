using Interfaces.Maladies.Types;

namespace Interfaces.Maladies
{
    public interface IMaladie
    {
        string Name { get; }
        ITupleValue FreqCar { get; }
        ITupleValue Temperature { get; }
        bool AdnSain { get;  }
        ITupleValue Depression { get; }
    }
}