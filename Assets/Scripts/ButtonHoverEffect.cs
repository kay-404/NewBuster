using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 cachedScale;

    float multipliedX;
    float multipliedY;
    float multipliedZ;

    void Start() {

        cachedScale = transform.localScale;

        multipliedX = transform.localScale.x * 1.1f; 
        multipliedY = transform.localScale.y * 1.1f; 
        multipliedZ = transform.localScale.z * 1.1f; 
    }

    public void OnPointerEnter(PointerEventData eventData) {

        transform.localScale = new Vector3(multipliedX, multipliedY, multipliedZ);
    }

    public void OnPointerExit(PointerEventData eventData) {

        transform.localScale = cachedScale;
    }
}

