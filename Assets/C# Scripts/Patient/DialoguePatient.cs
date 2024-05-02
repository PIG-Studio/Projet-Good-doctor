using UnityEngine;
    using TMPro;

    public class DialoguePatient : MonoBehaviour
{
    public GameObject boiteDialogue; // référence à la boîte de dialogue public static Type Text { get; }
    public TextMeshProUGUI _Text;
    public Patient.Patient Patient;
    private string CatchPhrase;
    private string Name;
    private bool Close;
    private void Awake()
    {
        Close = false;
    }

    private void Start()
    {
        boiteDialogue = gameObject.transform.GetChild(0).gameObject;
        _Text = boiteDialogue.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        boiteDialogue.SetActive(false); // le dialogue commence masqué
        CatchPhrase = Patient.CatchPhrase;
        Name = Patient.Name;
        _Text.text = Name;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Close = true;
            boiteDialogue.SetActive(true);
        }
    }
    
    

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Close = false; 
            boiteDialogue.SetActive(false);
            _Text.text = Name;
        }
    }

    private void Update()
    {
        if (Close && UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            _Text.text = CatchPhrase;
        }
    }
}