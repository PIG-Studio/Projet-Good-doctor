using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteSave : MonoBehaviour
{
    public static void SaveGame(SaveData playerData)
    {
        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", json);
        PlayerPrefs.Save();
    }

}
