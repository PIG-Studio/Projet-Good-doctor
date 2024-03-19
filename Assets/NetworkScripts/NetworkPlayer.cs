using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    
    private readonly NetworkVariable<Vector2> _pos = new(writePerm:NetworkVariableWritePermission.Owner);
    public readonly NetworkVariable<bool> isOnMapScene = new(writePerm:NetworkVariableWritePermission.Owner);
    private readonly NetworkVariable<bool> _movingUp = new(writePerm:NetworkVariableWritePermission.Owner);
    private readonly NetworkVariable<bool> _movingDown = new(writePerm:NetworkVariableWritePermission.Owner);
    private readonly NetworkVariable<bool> _movingLeft = new(writePerm:NetworkVariableWritePermission.Owner);
    private readonly NetworkVariable<bool> _movingRight = new(writePerm:NetworkVariableWritePermission.Owner);
    private readonly NetworkVariable<Vector2> _posRB = new(writePerm:NetworkVariableWritePermission.Owner);
    public SpriteRenderer sprite;
    public Animator anims;
    public Rigidbody2D rb;
    
    void Update()
    {
        if (IsOwner)
        {
            if (GameVariables.SceneName_Current == "MapHospital")
            {
                _pos.Value = transform.position;
                isOnMapScene.Value = true;
                sprite.enabled = true;
                _movingUp.Value = anims.GetBool("MovingUp");
                _movingDown.Value = anims.GetBool("MovingDown");
                _movingLeft.Value = anims.GetBool("MovingLeft");
                _movingRight.Value = anims.GetBool("MovingRight");
                _posRB.Value = rb.position;
            }
            else
            {
                isOnMapScene.Value = false;
                sprite.enabled = false;
            }
        }
        else
        {
            
            sprite.enabled = isOnMapScene.Value;
            if (sprite.enabled)
            {
                transform.position = _pos.Value;
                anims.SetBool("MovingUp", _movingUp.Value);
                anims.SetBool("MovingDown", _movingDown.Value);
                anims.SetBool("MovingLeft", _movingLeft.Value);
                anims.SetBool("MovingRight", _movingRight.Value);
                rb.position = _posRB.Value;
            }
        }
        
    }
}
