using System;
using Exceptions;
using GameCore.Variables;
using Interfaces;
using Interfaces.Destination;
using Interfaces.Entites;
using Interfaces.Maladies;
using Interfaces.Maladies.Types;
using Interfaces.Patient;
using UnityEngine;
using Maladies.Base;
using PNJ;
using TypeExpand.Int;
using UnityEngine.AI;

namespace Patient.Base
{
    public class PatientBase : IPnj , IPatient, ISpawnableGo, ICanGoInDesk
    {
        // Creer Patient(S) Genere le random et classe les patients en fct de leur maladie et utilise Patient comme Moule
        /// <summary>
        /// Instantie un patient a l'entrée de l'hôpital
        /// </summary>
        public string Id { get; }               public string Name { get; set; }                public string CatchPhrase { get; set; }
        public bool IsLying { get; set; }       public Maladie Sickness {get;set;}              /*public int Mood { get; set; }*/
        public IValue FreqCar { get; set; }     public IValue Temperature { get; set; }         public IValue Depression { get; set; }
        public IAdn Adn { get; set; }           public bool AdnSain { get; set; }               public bool IsAlive { get; set; }
        public bool AnalyseAdn { get; set; }    public bool AnalyseDepression { get; set; }     public Sprite Skin { get; set; }
        public Vector2 Position { get; set; }   
        public Animator AnimatorComponent { get; set; } public NavMeshAgent Agent { get; private set; }
        /// <summary>
        /// : IHasPrefab, stocke le prefab du patient 
        /// </summary>
        public GameObject Prefab { get; } = Resources.Load<GameObject>("Patient");
        
        public GameObject InstantiatedObject { get; set; }
        
        //ICanGOInDestination Implem
        public IDestination Destination { get; set; } public bool EnAttente { get; set; }
        
        //ICanGoInDesk Implem
        public Sprite AltSprite { get; set; } public bool DansBureau { get; set; }

        public uint Siege { get; set; }
        
        Pnj InstancePnj { get; set; }


        public PatientBase(IMaladie sickness ,IAdn adn, bool adNormal , IValue depression, IValue temperature ,
            IValue freqCar ,string catchPhrase ,bool lie /*int mood*/, Sprite skin , string name , Vector2? position = null)
        {
            Id = name;                              Name = name;                            CatchPhrase = catchPhrase;
            
            IsLying = lie;      if (sickness is Maladie) { Sickness = (Maladie)sickness; }  //Mood = mood;
            
            FreqCar = freqCar;                      Temperature = temperature;              Depression = depression;
            
            Adn = adn;                              AdnSain = adNormal;                     IsAlive = true;
            
            AnalyseAdn = false;                     AnalyseDepression = false;              Skin = skin;
            
            Position = position ?? new Vector2(3, 6); // entrée hôpital
            
            Spawn();
            ChooseDestination();
        }

        public void Spawn()
        {
            this.Instancier();
            AnimatorComponent = InstantiatedObject!.GetComponent<Animator>();
            this.AddNavMeshAgent();
            Agent = InstantiatedObject.GetComponent<NavMeshAgent>();
            this.LinkAnimator();
            InstancePnj = InstantiatedObject.AddComponent<Pnj>();
            InstancePnj.Patient = this;
            InstantiatedObject.AddComponent<DialoguePatient>().Base = this;
        }


        /// <summary>
        /// <value>WIP, bien avance</value>
        /// Choisit la destination du patient, pour le moment une seule et fixee, + tard aleatoirement
        /// <remarks> RISQUE DE BOUCLE INFINI SI AUCUNE DESTINATION DISPO, bien regler le nombre de patients max pour eviter ca</remarks>
        /// </summary>
        public void ChooseDestination()
        {
            uint i = 0;
            while (true)
            {
                Destination = Variable.AllDestinations[(Variable.DeskDestinations.Length-1).RandomInt()];
                
                i++;
                if (i > 100) { throw new LogicException("Aucune destination disponible"); }
                if (!Destination.IsFull) 
                {
                    InstancePnj.Destination = Destination;
                    Agent.SetDestination(Destination.PtArrivee);
                    break;
                }
            }
        }

        public void Leave()
        {
            throw new NotImplementedException();
        }

        public void Kill()
        {
            throw new NotImplementedException();
        }

        public void StartWaiting()
        {
            Agent.SetDestination(Destination.PtAttente[Siege].coordonees);
            EnAttente = true;
            
        }
        
        public void EndWaiting()
        {
            throw new NotImplementedException();
        }

        public void GoInDesk()
        {
            throw new NotImplementedException();
        }

        public void SortirBureau()
        {
            throw new NotImplementedException();
        }
    }
}