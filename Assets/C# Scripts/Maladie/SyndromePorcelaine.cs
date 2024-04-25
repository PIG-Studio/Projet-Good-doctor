namespace C__Scripts.Maladie
{
    public class SyndromePorcelaine : Maladie
    {
        public SyndromePorcelaine(string "Syndrome de Porcelaine", (uint, uint) freqcar, (uint, uint) temp, bool normalADN, (uint, uint) depression) : base(name, freqcar, temp, normalADN, depression)
        {
        }
    }
}