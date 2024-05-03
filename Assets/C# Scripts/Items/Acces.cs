using System;
using Items.Implementation;
using JetBrains.Annotations;


namespace Items
{
    /// <summary>
    /// Classe listant les methodes pour creer des Items
    /// </summary>
    public static class Acces
    {
        /// <summary>
        /// retourne une Madeleine
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [CanBeNull]
        public static Madeleine Madeleine()
        {
            if (Implementation.Madeleine.Nbr >= 60)
            {
                return null;
                //throw new NotImplementedException("la maladie de quand tu manges trop de madeline"); BONNE IDEE, MAIS PAS A METTRE ICI
            }

            return new Madeleine(1);
        }


        /// <summary>
        /// retourne une Chevre
        /// </summary>
        /// <returns></returns>
        [CanBeNull]
        public static Chevre Chevre()
        {
            if (Implementation.Chevre.Nbr >= 50)
            {
                return null;
                //throw new NotImplementedException("trop de chevre le joueur est mort pietiné par les chevres"); SAME
            }

            return new Chevre(1);
        }


        /// <summary>
        /// retourne un Cafe
        /// </summary>
        /// <returns></returns>
        [CanBeNull]
        public static Coffee Coffee()
        {
            if (Implementation.Coffee.Nbr == 42)
            {
                //throw new NotImplementedException("on peux pas faire mourir le joueur encore");
                return null;
            }

            return new Coffee(1);
        }


        /// <summary>
        /// retourne une Corde
        /// </summary>
        /// <returns></returns>
        [CanBeNull]
        public static Corde Corde()
        {
            if (Implementation.Corde.Nbr == 0)
            {
                return new Corde(1);
            }

            return null;
        }


        /// <summary>
        /// retourne un Foie
        /// </summary>
        /// <returns></returns>
        [CanBeNull]
        public static Foie Foie()
        {
            if (Implementation.Foie.Nbr == 0)
            {
                return new Foie(1);
            }

            return null;
        }


        /// <summary>
        /// retourne un Oeil
        /// </summary>
        /// <returns></returns>
        [CanBeNull]
        public static Oeil Oeil()
        {
            if (Implementation.Oeil.Nbr < 2)
            {
                return new Oeil(1);
            }

            return null;
        }


        /// <summary>
        /// retourne un PostIt
        /// </summary>
        /// <returns></returns>
        [CanBeNull]
        public static PostIt Postit()
        {
            if (PostIt.Nbr == 0)
            {
                return new PostIt(1);
            }

            return null;
        }


        /// <summary>
        /// retourne un nounours
        /// </summary>
        /// <returns></returns>
        [CanBeNull]
        public static TeddyBear Teddybear()
        {
            if (TeddyBear.Nbr == 0)
            {
                return new TeddyBear(1);
            }

            return null;
        }
    }
}