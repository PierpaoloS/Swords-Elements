using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TakeDamageEffect : MonoBehaviour
{
    public Image image;
    public Color color;
    public Color alpha;
    public void ChangeAlphaValue()
    {
       // print("Sono in takedamageeffect");
        image.color = alpha;
        Invoke("ResetAlphaValue", 0.1f);
    }

    public void ResetAlphaValue()
    {
        image.color = color;
    }
}
