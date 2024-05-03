using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FillValueNumber : MonoBehaviour
{
    [FormerlySerializedAs("TargetImage")] public Image targetImage;
    // Update is called once per frame
    void Update()
    {
        float amount = targetImage.fillAmount * 100;
        gameObject.GetComponent<Text>().text = amount.ToString("F0");
    }
}
