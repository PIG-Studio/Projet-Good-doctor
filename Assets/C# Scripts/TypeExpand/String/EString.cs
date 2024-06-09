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
        
        
        public static bool IsIpv4(this string str)
        {
            if(str is null || str.Length < 7 || str.Length > 15)
                return false;
            
            var split = str.Split('.');
            if (split.Length != 4)
                return false;
            foreach (var s in split)
            {
                if (!s.ToInt().HasValue)
                    return false;
                if (s.ToInt() is not (>= 0 and <= 255))
                    return false;
            }

            return true;
        }
    }
}