using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ProfileHandler : MonoBehaviour
{
    CharacterSO thisCharacter;
    Image characterImage;
    void Start()
    {
        thisCharacter = gameObject.GetComponent<Character>().CharacterData;

        Transform tempTransform = gameObject.transform.GetChild(0);
        characterImage = tempTransform.gameObject.GetComponent<Image>();
    }

    [YarnCommand("UpdateImage")]
    public void UpdateImage(string characterEmotion)
    {
        switch(characterEmotion)
        {
            case"Happy":
            if (thisCharacter.HappyImage != null)
            {
                characterImage.sprite = thisCharacter.HappyImage;
            }
            break;

            case"Upset":
            if (thisCharacter.UpsetImage != null)
            {
                characterImage.sprite = thisCharacter.UpsetImage;
            }
            break;

            default:
            characterImage.sprite = thisCharacter.NeutralImage;
            break;
        }
    }

    [YarnCommand("ResetImageToNeutral")]
    public void ResetImageToNeutral()
    {
        characterImage.sprite = thisCharacter.NeutralImage;
    }
}
