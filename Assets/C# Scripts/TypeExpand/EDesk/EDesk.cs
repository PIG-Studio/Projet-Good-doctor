using Desks;
using Destinations.Lieux.Bureaux;
using Interfaces.Destination;
using JetBrains.Annotations;

namespace TypeExpand.EDesk
{
    public static class EDesk
    {
        [CanBeNull]
        public static IDeskDestination ToDeskDestination(this Desk bureau)
        {
            return bureau.SceneName switch
            {
                "DESK_Base" => Bureau.DESK_Base(bureau),
                "DESK_Upgraded" => Bureau.DESK_Upgraded(bureau),
                _ => null
            };
        }
    }
}