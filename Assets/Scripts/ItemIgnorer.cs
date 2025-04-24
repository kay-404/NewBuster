//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ItemIgnorer : MonoBehaviour
{
    void Start()
    {
        Image tempImg = gameObject.GetComponent<Image>();
        RawImage tempRawImg = gameObject.GetComponent<RawImage>();
        if (tempImg != null)
        {
            tempImg.raycastTarget = false;
        }
        else if(tempRawImg != null)
        {
            tempRawImg.raycastTarget = false;
        }
    }
}
