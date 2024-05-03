using UnityEngine;

namespace GameObjectScripts.Unique_Objects_Scripts
{
    public class UniqueMultiObject : MonoBehaviour
    {
        private static bool _created;

        private void Start()
        {
            if (_created)
            {
                Destroy(gameObject);
                return;
            }

            _created = true;
        }
    }
}