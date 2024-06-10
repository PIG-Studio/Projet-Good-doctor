namespace Interaction.Base
{
    /*public class PlayerInteraction : MonoBehaviour
    {
        private Camera playerCamera; // Référence à la caméra du joueur
        public float interactionRange = 2f; // Portée de l'interaction

        void Start()
        {
            playerCamera = Camera.main; // Récupère la caméra principale du joueur
        }

        void Update()
        {
            // Lance un raycast depuis la position de la caméra du joueur dans la direction du regard
            Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            // Vérifie s'il y a une collision avec un objet dans la portée d'interaction
            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                // Vérifie si l'objet avec lequel le joueur interagit a un script d'interaction
                ObjectInteraction objectInteraction = hit.collider.GetComponent<ObjectInteraction>();
                if (objectInteraction != null)
                {
                    // Appelle la fonction d'interaction de l'objet
                    objectInteraction.Interact();
                }
            }
        }
    }*/
}
