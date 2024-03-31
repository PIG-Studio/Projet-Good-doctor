using System.Collections.Generic;
using Interfaces;
using Unity.Netcode;
using UnityEngine;

public class Desk
{
    public string SceneName { get; }
    public Inventory Inventory { get; }
    public static Dictionary<string, Desk> SceneDeskDict { get; set; }

    public bool HasChanged { get; set; }
    
    public Desk(string sceneName)
    {
        SceneName = sceneName;
        Inventory = new Inventory();
        SceneDeskDict.Add(sceneName, this);
        Debug.Log("ADDED 1 DESK");
        HasChanged = true;
    }

}   