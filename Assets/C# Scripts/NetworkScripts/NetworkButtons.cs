using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkButtons : MonoBehaviour
{
    public GameObject soloPlayer; //player to activate when we stop hosting or disconnect
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            Debug.Log(DesksConvert.ValidString(GameVariables.SceneName_Current));
            Debug.Log(GameVariables.SceneName_Current);
            if (DesksConvert.ValidString(GameVariables.SceneName_Current)) // Si la scene actuelle est le bureau
            {
                if (GUILayout.Button("Host")) {NetworkManager.Singleton.StartHost();soloPlayer.SetActive(false);}
                //if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
                if (GUILayout.Button("Client")) {NetworkManager.Singleton.StartClient();soloPlayer.SetActive(false);}
            }
            if (GameVariables.SceneName_Current == "MapHospital") {soloPlayer.SetActive(true);}
            else { soloPlayer.SetActive(false); }
        }
        else
        {
            if (NetworkManager.Singleton.IsServer)
            {
                GUILayout.Label("Server");
                GUILayout.Label($"ID: {NetworkManager.Singleton.LocalClientId}");
                GUILayout.Label($"IP : {NetworkManager.Singleton.ConnectedHostname}");
                GUILayout.Label($"Connected : {NetworkManager.Singleton.ConnectedClients.Count}");
                
                if (GUILayout.Button("Shutdown")) {NetworkManager.Singleton.Shutdown(); 
                    soloPlayer.transform.position = NetworkManager.Singleton.ConnectedClients[0].PlayerObject.transform.position; 
                    soloPlayer.SetActive(true);}
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