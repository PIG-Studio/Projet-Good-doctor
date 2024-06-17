namespace Super.Interfaces.Patient
{
    public interface IAdn
    {
        string AdnValue { get; }
        public bool IsHealthy { get; set; }
    }
}