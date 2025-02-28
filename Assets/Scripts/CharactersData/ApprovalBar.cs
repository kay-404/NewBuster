using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Yarn.Unity;
using Unity.VisualScripting;

public class ApprovalBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CharacterSO thisCharacter;

    void Start()
    {
        thisCharacter = gameObject.GetComponent<Character>().CharacterData;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ApprovalBarUI.Instance.ApprovalSlider.value = thisCharacter.GetApprovalCount(0);
        ApprovalBarUI.Instance.ApprovalText.text = thisCharacter.UpdateApprovalText();

        ApprovalBarUI.Instance.NameText.text = thisCharacter.characterName;

        ApprovalBarUI.Instance.ApprovalBar.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Invoke("deactivateApprovalBar", 2);
    }

    private void deactivateApprovalBar()
    {
        ApprovalBarUI.Instance.ApprovalBar.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    /// <param name="approvalChange">Pass in negative if </param>

    [YarnCommand("UpdateApproval")]
    public void UpdateCharacterApproval(int approvalChange) 
    {
        ApprovalBarUI.Instance.ApprovalSlider.value = thisCharacter.GetApprovalCount(approvalChange);

        if(approvalChange >= 0)
        {
            ApprovalBarUI.Instance.PositiveDisplay.SetActive(true);
            Invoke("deactivateApprovalDisplay", 7);
        }
        else if(approvalChange < 0)
        {
            ApprovalBarUI.Instance.NegativeDisplay.SetActive(true);
            Invoke("deactivateDisapprovalDisplay", 7);
        }
    }

    private void deactivateDisapprovalDisplay()
    {
        ApprovalBarUI.Instance.NegativeDisplay.SetActive(false);
    }

    private void deactivateApprovalDisplay()
    {
        ApprovalBarUI.Instance.NegativeDisplay.SetActive(false);
    }
}
