using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public Scene LoadSceneSave()
    {
        return playerData.SavedScene;
    }
    
    public void SaveCurrentScene(Scene currentScene)
    {
        playerData.SavedScene = currentScene;
    }

    public int GetCurrentDaySave()
    {
        return playerData.CurrentDay;
    }
    /// <summary>
    /// Sets current day player is on in save file.
    /// </summary>
    /// <param name="dayValueChange">Sets day value. Pass in as equation: GetCurrentDaySave() + 1</param>
    public void SetCurrentDaySave(int newDayCount)
    {
        playerData.CurrentDay = newDayCount;
        SaveJson();
    }

    public int GetCurrentScoreSave()
    {
        return playerData.CurrentScore;
    }

    /// <summary>
    /// Sets current score player in save file. Should be set at end of day.
    /// </summary>
    /// <param name="dayValueChange">Sets score value. Pass in as equation: GetCurrentScoreSave() + 1</param>
    public void SetScoreSave(int newScoreCount)
    {
        playerData.CurrentScore = newScoreCount;
        SaveJson();
    }

    public int GetHighscoreSave()
    {
        return playerData.Highscore;
    }

    /// <summary>
    /// Sets current score player in save file. Should be set at end of day.
    /// </summary>
    /// <param name="dayValueChange">Sets score value. Pass in as equation: GetCurrentScoreSave() + 1</param>
    public void SetHighscoreSave(int newHighscoreCount)
    {
        playerData.Highscore = newHighscoreCount;
        SaveJson();
    }


    [SerializeField] private PlayerData playerData = new PlayerData();
    private static Mutex mutex = new Mutex(false);
    private static SaveData instance;

    public static SaveData Instance
    {
        get{return instance;}
    }

    private void Awake()
    {
        //Prevents a second class instance being created by destroying on awake, if one exists.
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }   
        else
        {
            instance = this;
        }
        //LoadJson();
    }

    public void SaveJson()
    {
        mutex.WaitOne();

        string playersData = JsonUtility.ToJson(playerData);
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        System.IO.File.WriteAllText(filePath, playersData);

        mutex.ReleaseMutex();
    }

    public PlayerData LoadJson()
    {
        try{
            string filePath = Application.persistentDataPath + "/PlayerData.json";
            string playersData = System.IO.File.ReadAllText(filePath);

            playerData = JsonUtility.FromJson<PlayerData>(playersData);
        }

        catch{
            mutex.WaitOne();

            string playersData = JsonUtility.ToJson(playerData);
            string filePath = Application.persistentDataPath + "/PlayerData.json";
            System.IO.File.WriteAllText(filePath, playersData);

            mutex.ReleaseMutex();
        }

        return playerData;
    }

    public void ResetGameData()
    {
        playerData.CurrentDay = 0;
        playerData.CurrentScore = 0;
    }
}

[System.Serializable]
public class PlayerData
{
    
    public Scene SavedScene;
    //0 = intro
    public int CurrentDay;
    public int CurrentScore;
    public int Highscore;


    //character approval
    public int AdamApproval;
    public int AlyceApproval;
    public int AshleyApproval;
    public int BenjaminApproval;
    public int CliffApproval;
    public int DarleneApproval;
    public int DebraApproval;
    public int DonnaApproval;
    public int DougApproval;
    public int HelenApproval;
    public int JamesApproval;
    public int JayApproval;
    public int LouiseApproval;
    public int MelvinApproval;
    public int OliverApproval;
    public int RichieApproval;
    public int RobertApproval;
    public int StevenApproval;
    public int StuartApproval;
}