using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ProfileHandler : MonoBehaviour
{
    [SerializeField] public CharacterSO ThisCharacter;
    Image characterImage;
    void Start()
    {
        Transform tempTransform = gameObject.transform.GetChild(0);
        characterImage = tempTransform.gameObject.GetComponent<Image>();
    }

    [YarnCommand("UpdateImage")]
    public void UpdateImage(string characterEmotion)
    {
        switch(characterEmotion)
        {
            case"Happy":
            if (ThisCharacter.HappyImage != null)
            {
                characterImage.sprite = ThisCharacter.HappyImage;
            }
            break;

            case"Upset":
            if (ThisCharacter.UpsetImage != null)
            {
                characterImage.sprite = ThisCharacter.UpsetImage;
            }
            break;

            default:
            characterImage.sprite = ThisCharacter.NeutralImage;
            break;
        }
    }

    [YarnCommand("ResetImageToNeutral")]
    public void ResetImageToNeutral()
    {
        characterImage.sprite = ThisCharacter.NeutralImage;
    }
}
