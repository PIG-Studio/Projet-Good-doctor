using System;
using C__Scripts.Item;
using JetBrains.Annotations;


/// <summary>
/// Classe listant les methodes pour creer des Items
/// </summary>
public static class Items
{// permet de créeer des nouveaux Objets
    
    /// </summary>
    /// <param name="qte">La quantite a creer</param>
    /// <returns></returns>
    [NotNull]
    public static Madeleine MADELEINE()
    {
        if (Madeleine.Nbr == 60)
        {
            throw new NotImplementedException("la maladie de quand tu manges trop de madeline");
        }
        return new Madeleine(1);
    }

    public static Chevre CHEVRE()
    {
        if (Chevre.Nbr == 50)
        {
            throw new NotImplementedException("trop de chevre le joueur est mort pietiné par les chevres");
        }
        return new Chevre(1);
    }

    public static Coffee COFFEE()
    {
        if (Coffee.Nbr == 42)
        {
            throw new NotImplementedException("on peux pas faire mourir le joueur encore");
        }
        else
            return new Coffee(1);
    }
    public static Corde CORDE()
    {
        if (Corde.Nbr == 0)
        {
            return new Corde(1);
        }

        return null;
    }
    public static Foie FOIE()
    {
        if (Foie.Nbr == 0)
        {
            return new Foie(1);
        }
        
        return null;
    }
    public static Oeil OEIL()
    {
        if (Oeil.Nbr < 2)
        {
            return new Oeil(1);
        }
        return null;
    }
    public static PostIt POSTIT()
    {
        if (PostIt.Nbr == 0)
        {
            return new PostIt(1);
        }
        
        return null;
    }
    public static TeddyBear TEDDYBEAR()
    {
        if (TeddyBear.Nbr == 0)
        {
            return new TeddyBear(1);
        }
        
        return null;
    }
}