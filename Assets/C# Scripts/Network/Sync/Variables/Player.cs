using Unity.Netcode;
using UnityEngine;
using GameCore.Variables;

namespace Network.Sync.Variables
{
    public class Player : NetworkBehaviour
    {
        private readonly NetworkVariable<Vector2> _pos = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _isOnMapScene = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingUp = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingDown = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingLeft = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingRight = new(writePerm: NetworkVariableWritePermission.Owner);
        public SpriteRenderer sprite;
        public Animator anims;
        public Rigidbody2D rb;
        
        private static readonly int MovingDown = Animator.StringToHash("MovingDown");
        private static readonly int MovingRight = Animator.StringToHash("MovingRight");
        private static readonly int MovingLeft = Animator.StringToHash("MovingLeft");
        private static readonly int MovingUp = Animator.StringToHash("MovingUp");

        void Update()
        {
            if (IsOwner)
            {
                if (Variable.SceneNameCurrent == "MapHospital")
                {
                    _pos.Value = transform.position;
                    _isOnMapScene.Value = true;
                    sprite.enabled = true;
                    _movingUp.Value = anims.GetBool(MovingUp);
                    _movingDown.Value = anims.GetBool(MovingDown);
                    _movingLeft.Value = anims.GetBool(MovingLeft);
                    _movingRight.Value = anims.GetBool(MovingRight);
                }
                else
                {
                    _isOnMapScene.Value = false;
                    sprite.enabled = false;
                }
            }
            else
            {

                sprite.enabled = _isOnMapScene.Value;
                if (sprite.enabled)
                {
                    transform.position = _pos.Value;
                    anims.SetBool(MovingUp, _movingUp.Value);
                    anims.SetBool(MovingDown, _movingDown.Value);
                    anims.SetBool(MovingLeft, _movingLeft.Value);
                    anims.SetBool(MovingRight, _movingRight.Value);
                }
            }

        }
    }
}