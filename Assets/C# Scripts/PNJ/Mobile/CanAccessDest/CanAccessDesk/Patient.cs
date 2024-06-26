using CustomScenes;
using GameCore.Constantes;
using GameCore.Variables;
using Super.Interfaces.Destination;
using Super.Interfaces.Maladies;
using Super.Interfaces.Maladies.Types;
using Maladies;
using Maladies.Base.SubTypes;
using Maladies.Base.SubTypes.Symptomes;
using Patient.Base;
using Super.Interfaces;
using Super.Interfaces.Entites;
using Super.Interfaces.Patient;
using TypeExpand.Int;
using TypeExpand.String;
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
        public bool Poisoned { get; set; }
        public int Age { get; set; }
        public NetworkVariable<bool> AnalyseAdn { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        public NetworkVariable<bool> AnalyseDepression { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        public IValue FreqCar { get; set; }
        public NetworkVariable<bool> IsAlive { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        public NetworkVariable<bool> IsLying { get; set; } = new(writePerm: NetworkVariableWritePermission.Server);
        
        private float TempsEcoulee { get; set; }
        
        private float TempsDernierPatient { get; set; }
        
        private float Wait { get; set; }
        public new void Start()
        {
            TempsDernierPatient = 0;
            Wait = 30f;
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
                Age = 70.RandomInt() + 18;
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
            TempsEcoulee = Time.time;
            // Si on est sur le serveur on continue
            if (!NetworkManager.Singleton.IsServer) return;
            if (TempsEcoulee - TempsDernierPatient > Wait && Destination is INormalDestination)
            {

                if (TempsEcoulee - TempsDernierPatient > Wait)
                {
                    Debug.Log("Twist !");
                    TempsDernierPatient = TempsEcoulee;
                    ChooseDestinationServerRpc();
                }
            }

            if (EnAttente.Value ||
                DansBureau.Value ||
                Navigation.remainingDistance > 2f ||
                Destination is null ||
                Navigation.pathPending) return;
            
            if (Destination.IsFull)
            {
                Debug.Log($"[Server] Destination {Destination.DestId} pleine, recherche d'une autre destination...");
                ChooseDestinationServerRpc();
                return;
            }
            Debug.Log($"[Server] Destination : {Destination.PtArrivee}, remaining : {Navigation.remainingDistance}, NavStatus : {Navigation.pathStatus}");
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
        
        
        [ServerRpc(RequireOwnership = false)]
        public void SyncOnConnectServerRpc()
        {
            Debug.Log("[Server] SyncOnConnectServerRpc() started");
            SyncOnConnectClientRpc(Phrase, Skin, Rb.simulated, Temperature.Valeur, Depression.Valeur, Adn.AdnValue, Adn.IsHealthy);
            Debug.Log("[Server] SyncOnConnectServerRpc() ended");
        }
        

        [ClientRpc]
        public void SyncOnConnectClientRpc(string phrase, uint skin, bool collisionsEnabled, uint temperature, uint depression, string adnValue, bool isV) 
        {
            
            Debug.Log("[Client] SyncOnConnectClientRpc() started");
            Phrase = phrase;
            Skin = skin;
            Rb.simulated = collisionsEnabled;
            Temperature = new Value(temperature);
            Depression = new Value(depression);
            Adn = new Adn(adnValue, isV);
            Debug.Log("[Client] SyncOnConnectClientRpc() ended");
        }
        
        
        [ServerRpc]
        public void EnterBureauServerRpc()
        {
            Debug.Log("[Server] EnterBureauServerRpc() started");
            
            Rb.simulated = false;
            DansBureau.Value = true;
            
            EndWaitingServerRpc();
            EnterBureauClientRpc();
            
            Debug.Log("[Server] EnterBureauServerRpc() ended");
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
            SkinDesk = Skin;
            Debug.Log("[Client] EnterBureauClientRpc() ended");
        }

        
        [ServerRpc]
        public void SortirBureauServerRpc(bool chercherNouvDest = true)
        {
            Debug.Log("[Server] SortirBureauServerRpc() started");
            
            Rb.simulated = true;
            DansBureau.Value = false;
            
            if (chercherNouvDest) ChooseDestinationServerRpc();
            SortirBureauClientRpc();
            
            Debug.Log("[Server] SortirBureauServerRpc() ended");
        }
        
        
        [ClientRpc]
        public void SortirBureauClientRpc()
        {
            Debug.Log("[Client] SortirBureauClientRpc() started");
            
            ConditionAffichage = () => Variable.SceneNameCurrent == Scenes.Map;
            Skin = SkinDesk;
            
            Debug.Log("[Client] SortirBureauClientRpc() ended");
        }
        
        
        /// <summary>
        /// Gere la destination du patient et appelle les methodes necessaires, lorsqu'il va a la sortie de l'hopital 
        /// </summary>
        [ServerRpc(RequireOwnership = false)]
        public void RenvoyerMaisonServerRpc()
        {
            Debug.Log("[Server] RenvoyerMaisonServerRpc() started");
            
            Destination = Variable.Sortie;
            Navigation.SetDestination(Destination.PtArrivee);
            
            SortirBureauServerRpc(false);
            RenvoyerMaisonClientRpc();
            
            Debug.Log("[Server] RenvoyerMaisonServerRpc() ended");
        }
        
        
        [ClientRpc]
        public void RenvoyerMaisonClientRpc()
        {
            Debug.Log("[Client] RenvoyerMaisonClientRpc() started");
            Phrase = "Je suis guéri !";
            Debug.Log("[Client] RenvoyerMaisonClientRpc() ended");
        }
        
        
        [ServerRpc]
        public void LeaveServerRpc()
        {
            Debug.Log("[Server] LeaveServerRpc() started");
            
            Destroy(gameObject);
            
            Debug.Log("[Server] LeaveServerRpc() ended");
        }
        
        
        [ClientRpc]
        public void LeaveClientRpc()
        {
            Debug.Log("[Client] LeaveClientRpc() started");
            Debug.Log("[Client] LeaveClientRpc() ended");
        }
        
        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void AddReputation()//fonction a utiliser quand patient quitte hôpital
        {
            int rep = Variable.CurrentlyRenderedDesk.Responsable.Reputation;
            if (/* adn  &&*/ FreqCar.Valeur <= 80 && FreqCar.Valeur >= 60 && Temperature.Valeur <= 37 && Temperature.Valeur >= 35 &&
                Depression.Valeur <= 2)
            {
                if (rep + 10 > 100)
                    Variable.SceneNameCurrent.ToDesk()!.Responsable.Reputation = 100;
                else
                {
                    Variable.SceneNameCurrent.ToDesk()!.Responsable.Reputation += 10;
                }
            }
            else if (Poisoned)
            {
                Variable.CurrentlyRenderedDesk.Responsable.Reputation -= 20;
            }
            else
            {
                if (rep - 10 < 100)
                    Variable.SceneNameCurrent.ToDesk()!.Responsable.Reputation = 0;
                else
                {
                    Variable.SceneNameCurrent.ToDesk()!.Responsable.Reputation -= 10;
                }
            }
        }
    }
}