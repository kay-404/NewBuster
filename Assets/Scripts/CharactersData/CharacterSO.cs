using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public enum ApprovalStatus
    {
        Despised,
        Disliked,
        Frenemies,
        Neutral,
        Acquaintances,
        Liked,
        Loved,
    }

    [SerializeField] public string characterName;
    [SerializeField] public Sprite NeutralImage;
    [SerializeField] public Sprite UpsetImage;
    [SerializeField] public Sprite HappyImage;

    /// <summary>
    /// Character's current approval w player on 1-100 scale.
    /// </summary>
    private int ApprovalRating; //50 is neutral

    /// <summary>
    /// display text for approval
    /// </summary>
    ApprovalStatus currentApproval;

    public string UpdateApprovalText()
    {
        ApprovalRating = SaveData.Instance.GetCharacterApproval(characterName);

        if(ApprovalRating <= 10) //15 below
        {
            currentApproval = ApprovalStatus.Despised;
        }
        else if (ApprovalRating >= 11 && ApprovalRating < 25) //11-24
        {
            currentApproval = ApprovalStatus.Disliked;
        }
        else if (ApprovalRating >= 25 && ApprovalRating < 45)
        {
            currentApproval = ApprovalStatus.Frenemies;
        }
        else if(ApprovalRating >= 45 && ApprovalRating <= 55)
        {
            currentApproval = ApprovalStatus.Neutral;
        }
        else if (ApprovalRating > 55 && ApprovalRating < 74)
        {
            currentApproval = ApprovalStatus.Acquaintances;
        }
        else if (ApprovalRating >= 75 && ApprovalRating < 90)
        {
            currentApproval = ApprovalStatus.Liked;
        }
        else if (ApprovalRating >= 91)
        {
            currentApproval = ApprovalStatus.Loved;
        }

        return currentApproval.ToString();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="approvalDifference">Pass in neg int to subtract, 0 if no update, pos for higher approval</param>
    /// <returns></returns>
    public int GetApprovalCount(int approvalDifference)
    {
        ApprovalRating += approvalDifference;
        return ApprovalRating;
    }

}
