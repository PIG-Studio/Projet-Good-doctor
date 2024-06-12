using CustomScenes;
using Destinations.Lieux.Sortie;
using GameCore.Constantes;
using GameCore.Variables;
using Interfaces.Destination;
using Interfaces.Entites;
using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using Interfaces.Patient;
using Maladies;
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
        public bool AnalyseAdn { get; set; }
        public bool AnalyseDepression { get; set; }
        public IValue FreqCar { get; set; }
        public bool IsAlive { get; set; }
        public bool IsLying { get; set; }
        
        public new void Start()
        {
            base.Start();
            
            if (Variable.NbOfPatients > Constante.MaxPatient)
            {
                Destroy(gameObject);
                return;
            }
            Variable.NbOfPatients++;
            
            (Sickness, IsLying) = Acces.GenererRandom();
            Adn = Attributs.GenAdn(Sickness.AdnSain);
            string nameTemp;
            (Phrase, nameTemp, Depression, Temperature, FreqCar)  = Attributs.Generer(Sickness);
            if (NetworkManager.Singleton.IsHost)
            {
                Name.Value = nameTemp;
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
            
            if (!NetworkManager.Singleton.IsHost) return;
            if (EnAttente.Value ||
                Navigation.remainingDistance > 2f ||
                Destination is null) return;
            
            if (Destination.IsFull)
            {
                Debug.Log($"Destination {Destination.DestId} pleine, recherche d'une autre destination...");
                ChooseDestinationServerRpc();
                return;
            }
            Debug.Log($"Destination {Destination.PtArrivee}, remaining : {Navigation.remainingDistance}");
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    deskDestination.Add(this);
                    break;
                case INormalDestination normalDestination:
                    if (normalDestination.PtArrivee == new Vector2(3,4)) {Debug.Log("Je vais mourrir !");LeaveServerRpc(); break;}
                    Debug.Log("Je vais PAS mourrir FDP !");
                    normalDestination.Add(this);
                    break;
            }
        }

        public void Kill()
        {
            throw new System.NotImplementedException();
        }

        [ServerRpc]
        public void LeaveServerRpc()
        {
            Debug.Log("LeaveServerRpc");
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
            EnterBureauClientRpc();
        }
        
        
        [ClientRpc]
        public void EnterBureauClientRpc()
        {
            Rb.simulated = false;
            ConditionAffichage = () => Variable.SceneNameCurrent == Variable.Desk.SceneName 
                                       && Navigation.remainingDistance < 2f 
                                       && DansBureau.Value;
        }

        [ServerRpc(RequireOwnership = false)]
        public void SyncOnConnectServerRpc()
        {
            Debug.Log("SyncOnConnectServerRpc");
            SyncOnConnectClientRpc(Phrase, Skin, Rb.simulated);
        }
        
        [ClientRpc]
        public void SyncOnConnectClientRpc(string phrase, uint skin, bool collisionsEnabled)
        {
            Debug.Log("SyncOnConnectClientRpc");
            Phrase = phrase;
            Skin = skin;
            Rb.simulated = collisionsEnabled;
        }
        
        [ServerRpc(RequireOwnership = false)]
        public void RenvoyerMaisonServerRpc()
        {
            Rb.simulated = true;
            DansBureau.Value = false;
            SortirBureauClientRpc();
            
            Navigation.SetDestination(Variable.Sortie.PtArrivee); //NE PAS CHANGE L ORDRE DES DEUX LIGNES
            Destination = Variable.Sortie;
            
            RenvoyerMaisonClientRpc();
            EnAttente.Value = false;
        }
        
        [ClientRpc]
        public void RenvoyerMaisonClientRpc()
        {
            Navigation.SetDestination(Variable.Sortie.PtArrivee); //NE PAS CHANGE L ORDRE DES DEUX LIGNES
            Destination = Variable.Sortie;
            
            Phrase = "Je suis guéri !";
            Debug.Log(ConditionAffichage + " affichage, " + EnAttente + " en attente");
        }
    }
}