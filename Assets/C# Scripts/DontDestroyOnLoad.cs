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

    public void OnSceneChange(int index)
    {
        if (Variable.SceneNameCurrent != Scenes.Menu) return;
        
        Variable.ListToCallOnSceneChange.RemoveAt(index);
        Destroy(_gameObject);
    }
    
    
}
