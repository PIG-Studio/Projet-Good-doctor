using UnityEngine;

public class GO_Unique_NetworkVariables : MonoBehaviour
{
    private static bool _created = false;

    private void Start()
    {
        if(_created)
        {
            Destroy(gameObject);
            return;
        }
        _created = true;
    }
}