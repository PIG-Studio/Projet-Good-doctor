namespace Interfaces.GameObjects
{
    public interface ICallOnSceneChange
    {
        /// <summary>
        /// Méthode appelée lors d'un changement de scène.
        /// </summary>
        /// <param name="index"></param>
        void OnSceneChange(int index);
    }
}