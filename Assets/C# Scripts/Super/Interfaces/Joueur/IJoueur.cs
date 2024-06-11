using Desks;

namespace Super.Interfaces.Joueur
{
    public interface IJoueur
    {
        uint Money { get; }
        int Reputation { get; }
        uint BureauActuel { get; }
        
    }
}