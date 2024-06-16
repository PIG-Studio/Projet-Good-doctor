using Inventories.Player;

namespace Super.Interfaces.Joueur
{
    public interface IJoueur
    {
        uint Money { get; set; }
        int Reputation { get; set; }
        uint? BureauActuel { get; }
        PlayerInventory Inventory { get; set; }
    }
}