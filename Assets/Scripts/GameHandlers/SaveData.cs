using UnityEngine;
using System.Threading;

public class SaveData : MonoBehaviour
{
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
        LoadJson();
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
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        string playersData = System.IO.File.ReadAllText(filePath);

        playerData = JsonUtility.FromJson<PlayerData>(playersData);
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
    //0 = intro
    public int CurrentDay;
    public int CurrentScore;
    public int Highscore;
}