using Super.Interfaces.Joueur;

namespace Super.Interfaces.Bureau
{
    public interface IHasResponsable
    {
        IJoueur Responsable { get; set; }
    }
}