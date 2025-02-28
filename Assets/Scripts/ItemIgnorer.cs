using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ItemIgnorer : MonoBehaviour
{
    void Start()
    {
        Image tempImg = gameObject.GetComponent<Image>();
        if (tempImg != null)
        {
            tempImg.raycastTarget = false;
        }
    }
}
