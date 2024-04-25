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
    }
}