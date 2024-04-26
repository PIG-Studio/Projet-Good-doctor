namespace Interfaces
{
    public interface IInteractible
    {
        public bool CanInteract (IInteractible a_OtherInteractible);
        public void Interact (IInteractible a_OtherInteractible);
    }
}