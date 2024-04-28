namespace Interfaces.Maladies.Symptomes.Maladie
{
    public interface ITupleValue
    {
        (uint,uint) Value { get; }
    }
}