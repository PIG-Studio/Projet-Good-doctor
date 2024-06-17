using Unity.Netcode;
using UnityEngine;
using GameCore.Variables;
using static CustomScenes.Manager;
using CustomScenes;
using TypeExpand.String;
using Unity.Netcode.Transports.UTP;


namespace Network.UI.Buttons
{
    /// <summary>
    /// Classe gerant les boutons lies au multijoueur
    /// </summary>
    public class Show : MonoBehaviour
    {
        public UnityTransport transport;
        private string _ip = "";
        private uint _compte;
        private string _textButton = "Connect";

        public void Start()
        {
            transport = GameObject.Find("Multiplayer").GetComponent<UnityTransport>();
        }

        private void OnGUI()
        {
            
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));

            // Si on est pas client ni host
            if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsHost)
            {
                // Si on est au bureau, on a acces au bouton pour host 
                /*if (Variable.SceneNameCurrent.IsDesk())
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
                }*/

                // Si on est dans le menu, on a acces au bouton pour etre client
                if (Variable.SceneNameCurrent == Scenes.Menu)
                {
                    /*if (GUILayout.Button("Client"))
                    {
                        NetworkManager.Singleton.StartClient();
                    }*/
                    GUILayout.TextField("IP");
                    _ip = GUILayout.TextField(_ip, new []{GUILayout.Width(200)});
                    transport.ConnectionData.Address = _ip;
                    if (GUILayout.Button(_textButton))
                    {
                        if (_textButton == "Invalid IPv4" && _compte > 500) { _textButton = "Connect"; _compte = 0; }
                        else if (_textButton == "Invalid IPv4") { _compte++; }
                        
                        if (!_ip.IsIpv4()) { _textButton = "Invalid IPv4";}
                        
                        NetworkManager.Singleton.StartClient();
                        ChangeScene(Scenes.DBase);
                    }
                }

                // On gere l instance du joueur solo, desactive par default
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
                    /*if (GUILayout.Button("Menu"))
                    {
                        NetworkManager.Singleton.Shutdown();
                        // TODO : savegame
                        ChangeScene("Menu");
                    }*/
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