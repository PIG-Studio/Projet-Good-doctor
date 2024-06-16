using Desks;
using Destinations.Lieux.Bureaux;
using Super.Interfaces.Destination;
using JetBrains.Annotations;

namespace TypeExpand.EDesk
{
    public static class EDesk
    {
        [CanBeNull]
        public static IDeskDestination ToDeskDestination(this Desk bureau)
        {
            // Déterminer le type de bureau et renvoyer la destination correspondante.
            return bureau.SceneName switch
            {
                "DESK_Base" => Bureau.DESK_Base(bureau),
                "DESK_2" => Bureau.DESK_2(bureau),
                "DESK_3" => Bureau.DESK_3(bureau),
                "DESK_4" => Bureau.DESK_4(bureau),
                _ => null
            };
        }
    }
}