using UnityEngine;
public class SwitchOnEscape : MonoBehaviour
{
        [SerializeField] private GameObject[] _gameObject;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                foreach (var eachGO in _gameObject)
                {
                    eachGO.SetActive(!eachGO.activeSelf);
                    
                }
            }
        }
}
