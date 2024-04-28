namespace Interfaces.Maladies.Base
{
    public interface IMaladie
    {
        string Name { get; }
        (uint, uint) FreqCar { get; }
        (uint, uint) Temperature { get; }
        bool NormalAdn { get;  }
        (uint, uint) Depression { get; }
    }
}