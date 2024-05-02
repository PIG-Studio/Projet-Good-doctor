using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "ScriptableObject/Item", order = 1)]
public class ItemsSo : ScriptableObject
{
    public string title;
    public string description;
    public Sprite icon;
    public int amount;
    public bool isStackable;

    [System.Serializable]
    public enum Type
    {
        Commun, Medicament
    }

    public Type type; 
}
