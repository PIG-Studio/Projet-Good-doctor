using UnityEngine;
    using System;
    using Patient;
    using TMPro;
    using UnityEngine.UI;
    using Input = UnityEngine.Windows.Input;


    public class DialoguePatient : MonoBehaviour
{
    public GameObject boiteDialogue; // référence à la boîte de dialogue public static Type Text { get; }
    public TextMeshProUGUI _Text;
    private Collider2D ohter;
    private void Awake()
    {
        _Text.text = Patient.Patient._phrase;
        Debug.Log(_Text.text);
    }

    private void Start()
    {
        boiteDialogue.SetActive(true); // le dialogue commence masqu
        Debug.Log("START DIALOGUE");
    }
        

    private void Update()
    {
        
    }
}