using System.Collections.Generic;
using Interfaces;
using UnityEngine;


public class Desk
{
    public string SceneName { get; }
    public Inventory Inventory { get; }
    public static Dictionary<string, Desk> ToDeskDict { get; private set; }

    public bool HasChanged { get; set; }
    
    public Desk(string sceneName)
    {
        SceneName = sceneName;
        Inventory = new Inventory();
        ToDeskDict = new Dictionary<string, Desk>();
        ToDeskDict.Add(sceneName, this);
        HasChanged = true;
    }

}   