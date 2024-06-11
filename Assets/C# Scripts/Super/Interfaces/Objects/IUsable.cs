namespace Interfaces.Objects
{
    public interface IUsable : IObject
    {
        /// <summary>
        /// Vérifie si l'objet est utilisable.
        /// </summary>
        /// <returns></returns>
        bool Usable()
        {
            if (Amount > 0) { return true; }
            return false;
        }
        
        /// <summary>
        /// Utilise l'objet.
        /// </summary>
        public void Use();
    }
}