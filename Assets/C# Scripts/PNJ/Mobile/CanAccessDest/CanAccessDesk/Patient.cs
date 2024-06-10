using CustomScenes;
using Desks;
using GameCore.Constantes;
using GameCore.Variables;
using Interfaces.Destination;
using Interfaces.Entites;
using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using Interfaces.Patient;
using Maladies;
using Patient.Base;
using UnityEngine;

namespace PNJ.Mobile.CanAccessDest.CanAccessDesk
{
    public class Patient : PnjCanGoInDest, ICanGoInDesk, IPatient
    {
        // ICanAccessDesk
        public Sprite AltSprite { get; set; }
        public IAdn Adn { get; set; }
        public bool DansBureau { get; set; }
        
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

            (Sickness, IsLying) = Acces.GenererRandom();
            Adn = Attributs.GenAdn(Sickness.AdnSain);
            (Phrase, Name, Depression, Temperature, FreqCar)  = Attributs.Generer(Sickness);
            ChooseDestination();
            ConditionAffichage = () => Variable.SceneNameCurrent == Scenes.Map;
        }
        
        public new void Update()
        {
            base.Update();
            
            if (!Unity.Netcode.NetworkManager.Singleton.IsHost) return;
            if (EnAttente || Navigation.remainingDistance > 2f || Destination is null) return;
            
            if (Destination.IsFull)
            {
                Debug.Log($"Destination {Destination.DeskId} pleine, recherche d'une autre destination...");
                ChooseDestination();
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

        public void SortirBureau()
        {
            ConditionAffichage = () => Variable.SceneNameCurrent == Scenes.Map;
            ChooseDestination();
        }

        public void EnterDesk()
        {
            ConditionAffichage = () => Variable.SceneNameCurrent == Variable.Desk.SceneName;
        }
    }
}