using JetBrains.Annotations;

namespace TypeExpand.String
{
    public static class EString
    {
        /// <summary>
        /// Convertit une chaîne de caractères en un bureau, en utilisant le dictionnaire de bureaux de scène
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [CanBeNull]
        public static Desks.Desk ToDesk(this string str)
        {
            return Desks.Desk.SceneDeskDict[str];
        }
    
        /// <summary>
        /// Vérifie si la chaîne de caractères représente un bureau existant
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
    
        /// <summary>
        /// Convertit une chaîne de caractères en un entier
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Vérifie si la chaîne de caractères contient un nombre
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasNbInString(this string str)
        {
            foreach (var chara in str)
            {
                if (chara is >= '0' and <= '9')
                    return true;
            }

            return false;
        }
        
        
        /// <summary>
        /// Vérifie si la chaîne de caractères représente une adresse IPv4 valide.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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