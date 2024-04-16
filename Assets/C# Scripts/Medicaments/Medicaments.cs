using JetBrains.Annotations;


/// <summary>
/// Classe listant les methodes pour creer des medicaments 
/// </summary>
public static class Medicaments
{
    
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
}
