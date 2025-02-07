using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ApprovalBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Slider approvalSlider;

    [SerializeField] CharacterSO thisCharacter;

    [SerializeField] TextMeshProUGUI approvalText;

    [SerializeField] TextMeshProUGUI nameText;

    [SerializeField] GameObject approvalBar;


    public void OnPointerEnter(PointerEventData eventData)
    {
        approvalSlider.value = thisCharacter.GetApprovalCount(0);
        approvalText.text = thisCharacter.UpdateApprovalText();

        nameText.text = thisCharacter.characterName;

        approvalBar.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        approvalBar.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    /// <param name="approvalChange">Pass in negative if </param>
    public void UpdateCharacterApproval(CharacterSO character, int approvalChange) 
    {
        character.GetApprovalCount(approvalChange);

    }
}
