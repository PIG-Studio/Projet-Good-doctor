using CustomScenes;
using GameCore.Variables;
using Interfaces.GameObjects;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour, ICallOnSceneChange
{
    private GameObject _gameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameObject = gameObject;
        DontDestroyOnLoad(_gameObject);
        Variable.ListToCallOnSceneChange.Add(this);
    }

    public void OnSceneChange()
    {
        if (Variable.SceneNameCurrent != Scenes.Menu) return;
        
        Variable.ListToCallOnSceneChange.Remove(this);
        Destroy(_gameObject);
    }
    
    
}
