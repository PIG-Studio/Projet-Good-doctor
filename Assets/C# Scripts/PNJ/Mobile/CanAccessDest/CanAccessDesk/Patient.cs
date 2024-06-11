using CustomScenes;
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
using Unity.Netcode;
using UnityEngine;

namespace PNJ.Mobile.CanAccessDest.CanAccessDesk
{
    public class Patient : PnjCanGoInDest, ICanGoInDesk, IPatient, ISyncOnConnectRpc
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
            if (EnAttente ||
                Navigation.remainingDistance > 2f ||
                Destination is null) return;
            
            if (Destination.IsFull)
            {
                Debug.Log($"Destination {Destination.DeskId} pleine, recherche d'une autre destination...");
                ChooseDestinationServerRpc();
                return;
            }
            
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    deskDestination.Add(this);
                    break;
                case INormalDestination normalDestination:
                    normalDestination.Add(this);
                    break;
            }
        }

        public void Kill()
        {
            throw new System.NotImplementedException();
        }

        public void Leave()
        {
            throw new System.NotImplementedException();
        }

        [ServerRpc]
        public void SortirBureauServerRpc()
        {
            Rb.simulated = true;
            ChooseDestinationServerRpc();
            SortirBureauClientRpc();
        }
        
        [ClientRpc]
        public void SortirBureauClientRpc()
        {
            Rb.simulated = true;
            ConditionAffichage = () => Variable.SceneNameCurrent == Scenes.Map && !DansBureau.Value && Navigation.remainingDistance > 2f ;
        }
        
        [ServerRpc]
        public void EnterBureauServerRpc()
        {
            Rb.simulated = false;
            DansBureau.Value = true;
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
    }
}