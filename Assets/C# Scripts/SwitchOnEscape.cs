using UnityEngine;
public class SwitchOnEscape : MonoBehaviour
{
        [SerializeField] public GameObject[] gameObjects;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                foreach (var eachGo in gameObjects)
                {
                    eachGo.SetActive(!eachGo.activeSelf);
                    
                }
            }
        }
}
