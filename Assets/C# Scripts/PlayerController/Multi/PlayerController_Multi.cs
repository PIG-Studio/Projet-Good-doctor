using CustomScenes;
using GameCore.Variables;

namespace PlayerController.Multi
{
    public class Multi : Base.PlayerController
    {
        new void Start()
        {
            base.Start();
        }

        private new void Update()
        {
            // Vérifie si le joueur est propriétaire et si la scène actuelle est la carte principale
            if (IsOwner && Variable.SceneNameCurrent == Scenes.Map)
            {
                vcam.SetActive(true);
                base.Update();
            }
            else
            {
                vcam.SetActive(false);
            }
        }
    }
}
