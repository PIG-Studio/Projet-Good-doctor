using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    
    private readonly NetworkVariable<Vector2> _pos = new(writePerm:NetworkVariableWritePermission.Owner);
    //private readonly NetworkVariable<Animator> _anim = new(writePerm:NetworkVariableWritePermission.Owner);
    
    void Update()
    {
        if (IsOwner)
        {
            _pos.Value = transform.position;
        }
        else
        {
            transform.position = _pos.Value;
        }
        
    }
}
