using UnityEngine;

public class RotationBlocker : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
}
