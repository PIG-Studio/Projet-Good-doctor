using CustomScenes;
using GameCore.Variables;
using Super.Abstract;
using UnityEngine;
using TypeExpand.Animator;

namespace PNJ.Base
{
    public class Pnj : APnj
    {
        public override string Name { get; protected set; }
        protected override Sprite Skin { get; set; }
        public override Vector2 Position { get; protected set; }

        protected override Animator Anims { get; set; }
        protected override SpriteRenderer Sprite { get; set; }
        protected override Rigidbody2D Rb { get; set; }

        public void Start()
        {
            Anims = gameObject.GetComponent<Animator>();
           Sprite = gameObject.GetComponent<SpriteRenderer>();
           Rb = gameObject.GetComponent<Rigidbody2D>();
        }

        public void Update()
        { 
            Debug.Log("Update from Pnj.cs");
            
            Debug.Log("IsHost from Pnj.cs");
            if (Variable.SceneNameCurrent == Scenes.Map) 
            { Sprite.enabled = true; Anims.UpdateAnim(Rb.velocity); Debug.Log("UpdateAnim from Pnj.cs");}
            else 
            { Sprite.enabled = false; }

            // Moved to patient
            /*if (Patient.EnAttente || AgentComp.remainingDistance > 2f) return;
            
            if (Destination.IsFull)
            {
                Debug.Log("Destination pleine, recherche d'une autre destination");
                Patient.ChooseDestination();
                return;
            }
            
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    deskDestination.Add(Patient);
                    break;
                case INormalDestination normalDestination:
                    normalDestination.Add(Patient);
                    break;
            }*/
        }
    }
}