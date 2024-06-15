namespace Super.Interfaces.Joueur
{
    public interface IJoueur
    {
        static uint  Money { get; }
        static int Reputation { get; }
        uint? BureauActuel { get; }
        
    }
}