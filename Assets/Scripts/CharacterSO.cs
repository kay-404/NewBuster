using UnityEngine;



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

    /// <summary>
    /// Character's current approval w player on 1-100 scale.
    /// </summary>
    [SerializeField] int approvalRating = 50; //50 is neutral

    /// <summary>
    /// display text for approval
    /// </summary>
    ApprovalStatus currentApproval;

    public string UpdateApprovalText()
    {
        if(approvalRating <= 10) //15 below
        {
            currentApproval = ApprovalStatus.Despised;
        }
        else if (approvalRating >= 11 && approvalRating < 25) //11-24
        {
            currentApproval = ApprovalStatus.Disliked;
        }
        else if (approvalRating >= 25 && approvalRating < 45)
        {
            currentApproval = ApprovalStatus.Frenemies;
        }
        else if(approvalRating >= 45 && approvalRating <= 55)
        {
            currentApproval = ApprovalStatus.Neutral;
        }
        else if (approvalRating > 55 && approvalRating < 74)
        {
            currentApproval = ApprovalStatus.Acquaintances;
        }
        else if (approvalRating >= 75 && approvalRating < 90)
        {
            currentApproval = ApprovalStatus.Liked;
        }
        else if (approvalRating >= 91)
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
        approvalRating += approvalDifference;
        return approvalRating;
    }

}
