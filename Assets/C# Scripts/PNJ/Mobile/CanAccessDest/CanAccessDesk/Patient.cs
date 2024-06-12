using CustomScenes;
using GameCore.Constantes;
using GameCore.Variables;
using Interfaces.Destination;
using Interfaces.Entites;
using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using Interfaces.Patient;
using Maladies;
using Maladies.Base.SubTypes.Symptomes;
using Patient.Base;
using Super.Interfaces;
using Super.Interfaces.Entites;
using Unity.Netcode;
using UnityEngine;

namespace PNJ.Mobile.CanAccessDest.CanAccessDesk
{
    public class Patient : PnjCanGoInDest, ICanGoInDesk, IPatient, ISyncOnConnectRpc, ICanExit
    {
        // ICanAccessDesk
        public Sprite AltSprite { get; set; }
        public IAdn Adn { get; set; }
        public NetworkVariable<bool> DansBureau { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        
        // IPatient
        public IValue Depression { get; set; }
        public IMaladie Sickness { get; set; }
        public IValue Temperature { get; set; }
        public NetworkVariable<bool> AnalyseAdn { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        public NetworkVariable<bool> AnalyseDepression { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        public IValue FreqCar { get; set; }
        public NetworkVariable<bool> IsAlive { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        public NetworkVariable<bool> IsLying { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        
        public new void Start()
        {
            base.Start();
            if (NetworkManager.Singleton.IsServer)
            {
                if (Variable.NbOfPatients > Constante.MaxPatient)
                {
                    Destroy(gameObject);
                    return;
                }
                Variable.NbOfPatients++;
                
                (Sickness, IsLying.Value) = Acces.GenererRandom();
                Adn = Attributs.GenAdn(Sickness.AdnSain);
                (Phrase, Name.Value , Depression, Temperature, FreqCar)  = Attributs.Generer(Sickness);
                ChooseDestinationServerRpc();
            }
            else
            {
                SyncOnConnectServerRpc();
                Debug.Log("Connected to server " + NetworkManager.Singleton.ConnectedHostname);
            }
            
        }


        public new void Update()
        {
            base.Update();
            
            if (!NetworkManager.Singleton.IsServer) return;
            if (EnAttente.Value ||
                DansBureau.Value ||
                Navigation.remainingDistance > 2f ||
                Destination is null) return;
            
            if (Destination.IsFull)
            {
                Debug.Log($"[Server] Destination {Destination.DestId} pleine, recherche d'une autre destination...");
                ChooseDestinationServerRpc();
                return;
            }
            Debug.Log($"[Server] Destination {Destination.PtArrivee}, remaining : {Navigation.remainingDistance}");
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    deskDestination.Add(this);
                    break;
                case INormalDestination normalDestination:
                    if (normalDestination.PtArrivee == new Vector2(3,4)) {Debug.Log("[Server] Je vais mourrir !");LeaveServerRpc(); break;}
                    Debug.Log("[Server] Je vais PAS mourrir FDP !");
                    normalDestination.Add(this);
                    break;
            }
        }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        [ServerRpc]
        public void LeaveServerRpc()
        {
            Debug.Log("[Server] LeaveServerRpc");
            LeaveClientRpc();
            Destroy(this);
        }
        [ClientRpc]
        public void LeaveClientRpc()
        {
            Debug.Log("LeaveClientRpc");
            Destroy(this);
        }

        [ServerRpc]
        public void SortirBureauServerRpc()
        {
            Rb.simulated = true;
            DansBureau.Value = false;
            ChooseDestinationServerRpc();
            SortirBureauClientRpc();
        }
        
        [ClientRpc]
        public void SortirBureauClientRpc()
        {
            Rb.simulated = true;
            ConditionAffichage = () => Variable.SceneNameCurrent == Scenes.Map && !DansBureau.Value;
            Debug.Log(ConditionAffichage);
        }
        
        [ServerRpc]
        public void EnterBureauServerRpc()
        {
            Rb.simulated = false;
            DansBureau.Value = true;
            EndWaitingServerRpc();
            Destination = null;
            EnterBureauClientRpc();
        }
        
        
        [ClientRpc]
        public void EnterBureauClientRpc()
        {
            Debug.Log("[Client] EnterBureauClientRpc() started");
            Rb.simulated = false;
            ConditionAffichage = () => Variable.SceneNameCurrent == Variable.Desk.SceneName 
                                       && Navigation.remainingDistance < 2f 
                                       && DansBureau.Value;
            Destination = null;
            Debug.Log("[Client] EnterBureauClientRpc() ended");
        }

        [ServerRpc(RequireOwnership = false)]
        public void SyncOnConnectServerRpc()
        {
            Debug.Log("[Server] SyncOnConnectServerRpc() started");
            SyncOnConnectClientRpc(Phrase, Skin, Rb.simulated, Temperature.Valeur, Depression.Valeur);
            Debug.Log("[Server] SyncOnConnectServerRpc() ended");
        }
        
        [ClientRpc]
        public void SyncOnConnectClientRpc(string phrase, uint skin, bool collisionsEnabled, uint temperature, uint depression)
        {
            
            Debug.Log("[Client] SyncOnConnectClientRpc() started");
            Phrase = phrase;
            Skin = skin;
            Rb.simulated = collisionsEnabled;
            Temperature = new Value(temperature);
            Depression = new Value(depression);
            Debug.Log("[Client] SyncOnConnectClientRpc() ended");
        }
        
        [ServerRpc(RequireOwnership = false)]
        public void RenvoyerMaisonServerRpc()
        {
            Debug.Log("[Server] RenvoyerMaisonServerRpc() started");
            Rb.simulated = true;
            DansBureau.Value = false;
            SortirBureauClientRpc();
            
            Navigation.SetDestination(Variable.Sortie.PtArrivee); //NE PAS CHANGE L ORDRE DES DEUX LIGNES
            Destination = Variable.Sortie;
            
            RenvoyerMaisonClientRpc();
            EnAttente.Value = false;
            Debug.Log("[Server] RenvoyerMaisonServerRpc() ended");
        }
        
        [ClientRpc]
        public void RenvoyerMaisonClientRpc()
        {
            Debug.Log("[Client] RenvoyerMaisonClientRpc() started");
            Phrase = "Je suis guéri !";
            Debug.Log("[Client] RenvoyerMaisonClientRpc() ended");
        }
    }
}