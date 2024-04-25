using UnityEngine;

public class UI_DeskInputManagement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(PARAMValues.EscapeKey))
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }
    }
}
