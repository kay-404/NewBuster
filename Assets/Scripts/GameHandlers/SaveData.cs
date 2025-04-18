using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;
using System.ComponentModel;
using System.Collections.Generic;

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

    public int GetCharacterApproval(string charactersName)
    {
        switch(charactersName)
        {
            case "Adam":
                return playerData.AdamApproval;
            case "Alyce":
                return playerData.AlyceApproval;
            case "Ashley":
                return playerData.AshleyApproval;
            case "Benjamin":
                return playerData.BenjaminApproval;
            case "Cliff":
                return playerData.CliffApproval;
            case "Darlene":
                return playerData.DarleneApproval;
            case "Debra":
                return playerData.DebraApproval;
            case "Donna":
                return playerData.DonnaApproval;
            case "Doug":
                return playerData.DougApproval;
            case "Helen":
                return playerData.HelenApproval;
            case "James":
                return playerData.JamesApproval;
            case "Jay":
                return playerData.JayApproval;
            case "Louise":
                return playerData.LouiseApproval;
            case "Melvin":
                return playerData.MelvinApproval;
            case "Oliver":
                return playerData.OliverApproval;
            case "Richie":
                return playerData.RichieApproval;
            case "Robert":
                return playerData.RobertApproval;
            case "Steven":
                return playerData.StevenApproval;
            case "Stuart":
                return playerData.StuartApproval;
            default:
                return 50;

        }
    }

    public void SetCharacterApproval(string charactersName, int newApprovalCount)
    {
             switch(charactersName)
        {
            case "Adam":
                playerData.AdamApproval += newApprovalCount;
                break;
            case "Alyce":
                playerData.AlyceApproval += newApprovalCount;
                break;
            case "Ashley":
                playerData.AshleyApproval += newApprovalCount;
                break;
            case "Benjamin":
                playerData.BenjaminApproval += newApprovalCount;
                break;
            case "Cliff":
                playerData.CliffApproval += newApprovalCount;
                break;
            case "Darlene":
                playerData.DarleneApproval += newApprovalCount;
                break;
            case "Debra":
                playerData.DebraApproval += newApprovalCount;
                break;
            case "Donna":
                playerData.DonnaApproval += newApprovalCount;
                break;
            case "Doug":
                playerData.DougApproval += newApprovalCount;
                break;
            case "Helen":
                playerData.HelenApproval += newApprovalCount;
                break;
            case "James":
                playerData.JamesApproval += newApprovalCount;
                break;
            case "Jay":
                playerData.JayApproval += newApprovalCount;
                break;
            case "Louise":
                playerData.LouiseApproval += newApprovalCount;
                break;
            case "Melvin":
                playerData.MelvinApproval += newApprovalCount;
                break;
            case "Oliver":
                playerData.OliverApproval += newApprovalCount;
                break;
            case "Richie":
                playerData.RichieApproval += newApprovalCount;
                break;
            case "Robert":
                playerData.RobertApproval += newApprovalCount;
                break;
            case "Steven":
                playerData.StevenApproval += newApprovalCount;
                break;
            case "Stuart":
                playerData.StuartApproval += newApprovalCount;
                break;
            default:
                break;

        }
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
        playerData.SavedScene = SceneManager.GetSceneByName("IntroScene");

        playerData.CurrentDay = 0;
        playerData.CurrentScore = 0;

        playerData.AdamApproval = 50;
        playerData.AlyceApproval = 50;
        playerData.AshleyApproval = 50;
        playerData.BenjaminApproval = 50;
        playerData.CliffApproval = 50;
        playerData.DarleneApproval = 50;
        playerData.DebraApproval = 50;
        playerData.DonnaApproval = 50;
        playerData.DougApproval = 50;
        playerData.HelenApproval = 50;
        playerData.JamesApproval = 50;
        playerData.JayApproval = 50;
        playerData.LouiseApproval = 50;
        playerData.MelvinApproval = 50;
        playerData.OliverApproval = 50;
        playerData.RichieApproval = 50;
        playerData.RobertApproval = 50;
        playerData.StevenApproval = 50;
        playerData.StuartApproval = 50; 
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


    public List<int> CharacterApprovals = new List<int>();

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
/*
    public Dictionary<string, int> ApprovalDict = new Dictionary<string, int>();
    public void Start()
    {
        ApprovalDict.Add("AdamApproval",AdamApproval);
        ApprovalDict.Add("AlyceApproval", AlyceApproval);
        ApprovalDict.Add("AshleyApproval", AshleyApproval);
        ApprovalDict.Add("BenjaminApproval", BenjaminApproval);
        ApprovalDict.Add("CliffApproval", CliffApproval);
        ApprovalDict.Add("DarleneApproval", DarleneApproval);
        ApprovalDict.Add("DebraApproval",DebraApproval);
        ApprovalDict.Add("DonnaApproval", DonnaApproval);
        ApprovalDict.Add("DougApproval", DougApproval);
        ApprovalDict.Add("HelenApproval", HelenApproval);
        ApprovalDict.Add("JamesApproval", JamesApproval);
        ApprovalDict.Add("JayApproval", JayApproval);
        ApprovalDict.Add("LouiseApproval", LouiseApproval);
        ApprovalDict.Add("MelvinApproval", MelvinApproval);
        ApprovalDict.Add("OliverApproval", OliverApproval);
        ApprovalDict.Add("RichieApproval", RichieApproval);
        ApprovalDict.Add("RobertApproval", RobertApproval);
        ApprovalDict.Add("StevenApproval", StevenApproval);
        ApprovalDict.Add("StuartApproval", StuartApproval);

    }*/

}