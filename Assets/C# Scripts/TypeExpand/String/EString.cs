using JetBrains.Annotations;
using Desks;
using Destinations.Lieux.Bureaux;
using GameCore.Variables;
using Interfaces.Destination;

namespace TypeExpand.String
{
    public static class EString
    {

            [CanBeNull]
            public static Desk ToDesk(this string str)
            {
                return Desk.SceneDeskDict[str];
            }
        
            public static bool IsDesk(this string str)
            {
                try
                {
                    return str.ToDesk() != null;
                }
                catch
                {
                    return false;
                }
            }
        
            [CanBeNull]
            public static int? ToInt(this string str)
            {
                int result = 0;
                foreach (var chara in str)
                {
                    if (chara is < '0' or > '9')
                        return null;
                    result = result * 10 + chara - '0';
                }

                return result;
            }
            
            public static bool HasNbInString (this string str)
            {
                foreach (var chara in str)
                {
                    if (chara is >= '0' and <= '9')
                        return true;
                }

                return false;
            }

            [CanBeNull]
            public static IDeskDestination ToDeskDestination(this string str)
            {
                return str switch
                {
                    "DESK_Base" => Bureau.DESK_Base(str.ToDesk()),
                    "DESK_Upgraded" => Bureau.DESK_Upgraded(str.ToDesk()),
                    _ => null
                };
            }
    }
}