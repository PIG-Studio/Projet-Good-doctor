using JetBrains.Annotations;

namespace GameCore.TypeExpand
{
    public static class String
    {

            [CanBeNull]
            public static Desk ToDesk(this string str)
            {
                return Desk.SceneDeskDict[str];
            }
        
            [NotNull]
            public static bool IsDesk(this string str)
            {
                try
                {
                    if (str.ToDesk() != null)
                        return true;
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        
    }
}