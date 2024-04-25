using C__Scripts.Medicaments;
using JetBrains.Annotations;


/// <summary>
/// Classe listant les methodes pour creer des medicaments 
/// </summary>
public static class Medicaments
{// permet de créeer des nouveaux médicamnents
    
    /// <summary>
    /// methode creant une nouvelle instance de cyamure
    /// </summary>
    /// <param name="qte">La quantite a creer</param>
    /// <returns></returns>
    [NotNull]
    public static Cyamure CYAMURE(uint qte)
    {
        return new Cyamure(qte);
    }
    
    public static Ananadvil ANANADVIL(uint qte)
    {
        return new Ananadvil(qte);
    }
    
    public static Chlorocoing CHLOROCOING(uint qte)
    {
        return new Chlorocoing(qte);
    }
    
    public static Doliprune DOLIPRUNE(uint qte)
    {
        return new Doliprune(qte);
    }
    
    public static Ibuprofigue IBUPROFIGUE(uint qte)
    {
        return new Ibuprofigue(qte);
    }
    
    public static Lisopoirine LISOPOIRINE(uint qte)
    {
        return new Lisopoirine(qte);
    }
    public static Opiomelon OPIOMELON(uint qte)
    {
        return new Opiomelon(qte);
    }
    public static Oxycodatte OXYCODATTE(uint qte)
    {
        return new Oxycodatte(qte);
    }
}
