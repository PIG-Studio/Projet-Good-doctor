using System;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// Interface pour les classes qui creent des objets UI
/// </summary>
public interface IUI_Create
{
    /// <summary>
    /// Methode pour creer un objet UI
    /// </summary>
    /// <param name="id"></param>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns>GameObject - L'objet cree</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static GameObject Create
        (string id,
        float posX,
        float posY,
        float width,
        float height) 
        => throw new NotImplementedException("Forgot to implement the Create " +
                                             "method in the class that implements IUI_Create");
}