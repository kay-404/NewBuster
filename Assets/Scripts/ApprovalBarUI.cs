using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ApprovalBarUI : MonoBehaviour
{
    [SerializeField] public Slider ApprovalSlider;
    [SerializeField] public TextMeshProUGUI ApprovalText;
    [SerializeField] public TextMeshProUGUI NameText;
    [SerializeField] public GameObject ApprovalBar;

    public static ApprovalBarUI Instance{get{return instance;}}
    private static ApprovalBarUI instance;
   
   void Awake()
   {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
   }
}
