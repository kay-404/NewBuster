using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public int CurrentDayCount;
    public DialogueRunner endShiftDialogue;
    public string endShiftDialogueText = "DayEndText";
    public static GameManager Instance{get{return instance;}}
    private static GameManager instance;
    
    [SerializeField] bool isDay1;
   
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
    void Start()
    {
        if (isDay1)
        {
            CharacterDataStorage.Instance.ResetCharacterApproval();
        }
    }

    public void EndDay()
    {

        endShiftDialogue.StartDialogue(endShiftDialogueText);
    }
}
