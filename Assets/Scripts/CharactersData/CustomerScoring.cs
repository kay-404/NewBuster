using System.Collections;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class CustomerScoring : MonoBehaviour
{
    public int tempDailyScore;
    public static CustomerScoring Instance{get{return instance;}}
    private static CustomerScoring instance;
    private int interactionScore;
    private int hoursWaited; 
    private int scoreBase = 50;

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

    [YarnCommand("UpdateScore")]
   public void UpdateScore(int scoreChange)
   {
        interactionScore += scoreChange;
   }

    [YarnCommand("TriggerInteractionScore")]
    public void EndInteraction()
    {
        CalculateScoreFromTime();

        ScorePopUpUI.Instance.TriggerPostCustomerScore(interactionScore);

        //adds to score for the day
        tempDailyScore += interactionScore;

        //resets interaction score for next interaction
        interactionScore = 0;
        hoursWaited = 0;
    }


    /// <summary>
    /// Call at every end of day's entire score and compare to high score.
    /// </summary>
    public void UpdateScoreSave()
    {
        //add daily score to total score
        SaveData.Instance.SetScoreSave(SaveData.Instance.GetCurrentScoreSave() + tempDailyScore);

        //check if current score is higher than high score
        if (SaveData.Instance.GetHighscoreSave() < SaveData.Instance.GetCurrentScoreSave())
        {
            //save over high score with current score
            SaveData.Instance.SetHighscoreSave(SaveData.Instance.GetCurrentScoreSave());
        }
    }

    /// <summary>
    /// Call when a customer is present and each time an hour passes
    /// </summary>
    public void UpdateWaitTime()
    {
        hoursWaited++;
    }

    private void CalculateScoreFromTime()
    {
        switch(hoursWaited)
        {
            case 1:
                interactionScore += scoreBase * 3; 
            break;

            case 2:
                interactionScore += scoreBase * 2;
            break;

            case 3:
                interactionScore += scoreBase * 1;
            break;

            default:
                interactionScore -= scoreBase/2 * hoursWaited;
            break;
        }
    }

}
