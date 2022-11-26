using UnityEngine;
using TMPro;

public class PopulationPanel : MonoBehaviour
{
    public TMP_Text title;
    public TMP_InputField name;
    public TMP_InputField count;
    public TMP_InputField color;
    public TMP_InputField speed;
    public TMP_Text mt;
    public UnityEngine.UI.Slider militant;

    private void Update()
    {
        if(mt != null)
        {
            mt.text = string.Format("Militant ({0}%) :", militant.value);
        }
    }
}
