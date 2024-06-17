using Inventories.Player;

namespace Super.Interfaces.Joueur
{
    public interface IJoueur
    {
        public uint Pv { get; set; }
        uint Money { get; set; }
        int Reputation { get; set; }
        uint? BureauActuel { get; }
        PlayerInventory Inventory { get; set; }
    }
}