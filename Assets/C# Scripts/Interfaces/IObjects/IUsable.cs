namespace Interfaces.IObjects
{
    public interface IUsable : IObject
    {
        bool Usable()
        {
            if (Amount > 0) { return true; }
            return false;
        }
        
        public void Use();
    }
}