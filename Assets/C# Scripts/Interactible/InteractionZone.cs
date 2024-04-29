using UnityEngine;
public abstract class InteractionZone : MonoBehaviour
{
    public abstract void OnTriggerEnter(Collider other);
}
