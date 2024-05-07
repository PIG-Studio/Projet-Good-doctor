using JetBrains.Annotations;

namespace TypeExpand.String
{
    public static class EString
    {

        [CanBeNull]
        public static Desks.Desk ToDesk(this string str)
        {
            return Desks.Desk.SceneDeskDict[str];
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

        public static bool HasNbInString(this string str)
        {
            foreach (var chara in str)
            {
                if (chara is >= '0' and <= '9')
                    return true;
            }

            return false;
        }
    }
}