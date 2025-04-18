using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CurrentDayCount;
    public DialogueRunner endShiftDialogue;
    public string endShiftDialogueText = "DayEndText";
    public static GameManager Instance{get{return instance;}}
    private static GameManager instance;
    
    [SerializeField] GameObject settingsMenu;
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
            SaveData.Instance.ResetGameData();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsMenu.SetActive(true);

            settingsMenu.transform.parent.gameObject.SetActive(true);
        }
    }
    public void EndDay()
    {
        CustomerScoring.Instance.UpdateScoreSave();

        endShiftDialogue.StartDialogue(endShiftDialogueText);
    }

    public void SaveGame()
    {
        SaveData.Instance.SaveCurrentScene(SceneManager.GetActiveScene());
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SaveData.Instance.LoadSceneSave().name);
    }
}
