using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public int sceneNumber;
    private int savedSceneNumber;
    public int skipScene;
    public bool skippingScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        savedSceneNumber = sceneNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (skippingScene == false)
        {
            sceneNumber = savedSceneNumber;
        }
    }

    public void SkipIntro()
    {
        skippingScene = true;
        sceneNumber = skipScene;
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
