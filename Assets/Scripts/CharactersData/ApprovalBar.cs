using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Yarn.Unity;
using UnityEditor.Rendering;
using Unity.VisualScripting;

public class ApprovalBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Slider approvalSlider;

    [SerializeField] TextMeshProUGUI approvalText;

    [SerializeField] TextMeshProUGUI nameText;

    [SerializeField] GameObject approvalBar;
    private CharacterSO thisCharacter;

    void Start()
    {
        thisCharacter = gameObject.GetComponent<Character>().CharacterData;
    }

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

    [YarnCommand("UpdateApproval")]
    public void UpdateCharacterApproval(int approvalChange) 
    {
        approvalSlider.value = thisCharacter.GetApprovalCount(approvalChange);
    }

}
