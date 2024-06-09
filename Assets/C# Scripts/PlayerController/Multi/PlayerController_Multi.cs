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
