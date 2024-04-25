namespace Interfaces
{
    public interface IMaladie
    {
        string Name { get; set; }
        (uint, uint) FreqCar { get; set; }
        (uint, uint) Temperature { get; set; }
        bool NormalADN { get; set; }
        (uint, uint) Depression { get; set; }
    }
}