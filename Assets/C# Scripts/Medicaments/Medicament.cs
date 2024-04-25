using C__Scripts.Medicaments;
using Interfaces;
using UnityEngine;


public abstract class Medicament : IMedicament
{// les médicaments ont tous les meme propriétés
    public string Name { get; set; }
    public delegate void Action();
    public uint Amount { get; set; }
    public Sprite Image { get; set; }
    public Action OnUseAction { get; set; }
    public Medicament(string name, Action inAction, uint qte, Sprite image)
    {
        Name = name;
        OnUseAction = inAction;
        Amount = qte;
        Image = image;
    }

}