using TMPro;
using UnityEngine;

public class CustomerScoring : MonoBehaviour
{
    public int tempDailyScore;
    public static CustomerScoring Instance{get{return instance;}}
    private static CustomerScoring instance;
    private int interactionScore;

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


   public void UpdateScore(int scoreChange)
   {
        interactionScore += scoreChange;
   }

    public void EndInteraction()
    {
        ScorePopUpUI.Instance.TriggerPostCustomerScore(interactionScore);

        //adds to score for the day
        tempDailyScore += interactionScore;

        //resets interaction score for next interaction
        interactionScore = 0;
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

}
