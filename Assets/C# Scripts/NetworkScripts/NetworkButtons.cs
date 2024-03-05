using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkButtons : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            Debug.Log(DesksConvert.ValidString(GameVariables.SceneName_Current));
            Debug.Log(GameVariables.SceneName_Current);
            if (DesksConvert.ValidString(GameVariables.SceneName_Current)) // Si la scene actuelle est le bureau
            {
                if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
                //if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
                if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
            }
        }
        else
        {
            if (NetworkManager.Singleton.IsServer)
            {
                GUILayout.Label("Server");
                GUILayout.Label($"ID: {NetworkManager.Singleton.LocalClientId}");
                GUILayout.Label($"IP : {NetworkManager.Singleton.ConnectedHostname}");
                GUILayout.Label($"Connected : {NetworkManager.Singleton.ConnectedClients.Keys.ToString()}");
                if (GUILayout.Button("Shutdown")) {NetworkManager.Singleton.Shutdown();}
            }
            else if (NetworkManager.Singleton.IsClient)
            {
                GUILayout.Label("Client");
                GUILayout.Label($"ID: {NetworkManager.Singleton.LocalClientId}");
                if (GUILayout.Button("Disconnect")) {NetworkManager.Singleton.Shutdown();CustomSceneManager.ChangeScene("Menu");}
            }
            
        }
        
        GUILayout.EndArea();

    }
}