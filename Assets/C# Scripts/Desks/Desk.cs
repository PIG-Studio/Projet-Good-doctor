using System.Collections.Generic;
using Inventories;
using UnityEngine;

namespace Desks
{
    public class Desk
    {
        public string SceneName { get; }
        public Inventories.Inventory Inventory { get; set; }
        public static Dictionary<string, Desk> SceneDeskDict { get; set; }

        public bool HasChanged { get; set; }

        public Desk(string sceneName)
        {
            SceneName = sceneName;
            Inventory = new Inventories.Inventory();
            Debug.LogError("ADDED " + sceneName + " DESK");
            SceneDeskDict.Add(sceneName, this);
            Debug.Log("ADDED 1 DESK");
            HasChanged = true;
        }

    }
}