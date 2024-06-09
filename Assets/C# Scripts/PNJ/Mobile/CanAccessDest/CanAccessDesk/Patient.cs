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
        public string CatchPhrase { get; set; }
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
            (CatchPhrase, Name, Depression, Temperature, FreqCar)  = Attributs.Generer(Sickness);
        }
        
        public new void Update()
        {
            base.Update();
            if (EnAttente || Navigation.remainingDistance > 2f) return;
            
            if (Destination.IsFull)
            {
                Debug.Log("Destination pleine, recherche d'une autre destination");
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
            throw new System.NotImplementedException();
        }

        public void GoInDesk()
        {
            throw new System.NotImplementedException();
        }
    }
}