using CustomScenes;
using GameCore.Variables;
using Unity.Netcode;
using UnityEngine;

namespace Joueur
{
    public class ifOwnerKeep : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (!transform.parent.GetComponent<NetworkObject>().IsOwner)
            {
                enabled = false;
            }
        }
        
        void Update()
        {
            if (Variable.SceneNameCurrent == Scenes.Map)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
                transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
