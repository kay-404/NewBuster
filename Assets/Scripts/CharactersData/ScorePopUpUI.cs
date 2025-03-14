using TMPro;
using UnityEngine;

public class ScorePopUpUI : MonoBehaviour
{
    [SerializeField] GameObject customerScorePanel;
    [SerializeField] TextMeshProUGUI scoreTotalText;
    [SerializeField] TextMeshProUGUI scoreUpdateText;

    public static ScorePopUpUI Instance{get{return instance;}}
    private static ScorePopUpUI instance;
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

    public void TriggerPostCustomerScore(int interactionScore)
    {
        scoreUpdateText.text = interactionScore.ToString();

        int tempTotal = interactionScore + SaveData.Instance.GetCurrentScoreSave();

        scoreTotalText.text = tempTotal.ToString();

        customerScorePanel.SetActive(true);

        Invoke("disableScorePanel", 3);
    }

    private void disableScorePanel()
    {
        customerScorePanel.SetActive(false);
    }
}
