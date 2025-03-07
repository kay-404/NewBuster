using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ApprovalBarUI : MonoBehaviour
{
    [SerializeField] public Slider ApprovalSlider;
    [SerializeField] public TextMeshProUGUI ApprovalText;
    [SerializeField] public TextMeshProUGUI NameText;
    [SerializeField] public GameObject ApprovalBar;

    /// <summary>
    /// Display for when player gains approval
    /// </summary>
    [SerializeField] public GameObject PositiveDisplay;

     /// <summary>
    /// Display for when player loses approval
    /// </summary>
    [SerializeField] public GameObject NegativeDisplay;

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

    public void DelayedApproval()
    {
        Invoke("deactivateApprovalDisplay", 5);
    }
    public void DelayedDisapproval()
    {
        Invoke("deactivateDisapprovalDisplay", 5);
    }
    
    private void deactivateDisapprovalDisplay()
    {
        NegativeDisplay.SetActive(false);
    }

    private void deactivateApprovalDisplay()
    {
        PositiveDisplay.SetActive(false);
    }
}
