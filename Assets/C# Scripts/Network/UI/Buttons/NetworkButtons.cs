using Unity.Netcode;
using UnityEngine;
using GameCore.Variables;
using static CustomScenes.Manager;
using CustomScenes;
using TypeExpand.String;


namespace Network.UI.Buttons
{
    /// <summary>
    /// Classe gerant les boutons lies au multijoueur
    /// </summary>
    public class Show : MonoBehaviour
    {
        public GameObject soloPlayer; //player to activate when we stop hosting or disconnect

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));

            // Si on est pas client ni host
            if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsHost)
            {
                // Si on est au bureau, on a acces au bouton pour host 
                if (Variable.SceneNameCurrent.IsDesk())
                {
                    if (GUILayout.Button("Host"))
                    {
                        NetworkManager.Singleton.StartHost();
                        soloPlayer.SetActive(false);
                    }

                    if (GUILayout.Button("Client"))
                    {
                        NetworkManager.Singleton.StartClient();
                        soloPlayer.SetActive(false);
                    }
                }

                // Si on est dans le menu, on a acces au bouton pour etre client
                if (Variable.SceneNameCurrent == Scenes.Menu)
                {
                    if (GUILayout.Button("Client"))
                    {
                        NetworkManager.Singleton.StartClient();
                        soloPlayer.SetActive(false);
                    }
                }

                // On gere l instance du joueur solo, desactive par default
                soloPlayer.SetActive(Variable.SceneNameCurrent == Scenes.Map);
            }
            else
            {
                // Si on est host
                if (NetworkManager.Singleton.IsHost)
                {
                    // Affichage des informations du serveur
                    GUILayout.Label("Server");
                    GUILayout.Label($"IP : {NetworkManager.Singleton.ConnectedHostname}");
                    GUILayout.Label($"Connected : {NetworkManager.Singleton.ConnectedClients.Count}");

                    // Bouton pour arreter le serveur
                    if (GUILayout.Button("Shutdown"))
                    {
                        soloPlayer.transform.position = NetworkManager.Singleton.ConnectedClients[0].PlayerObject
                            .transform.position;
                        soloPlayer.SetActive(true);
                        NetworkManager.Singleton.Shutdown();
                    }
                }
                // Si on est client
                else if (NetworkManager.Singleton.IsClient)
                {
                    // Affichage des informations du client
                    GUILayout.Label("Client");
                    GUILayout.Label($"ID: {NetworkManager.Singleton.LocalClientId}");

                    // Bouton pour se deconnecter
                    if (GUILayout.Button("Disconnect"))
                    {
                        NetworkManager.Singleton.Shutdown();
                        ChangeScene("Menu");
                    }
                }

            }

            GUILayout.EndArea();

        }
    }
}