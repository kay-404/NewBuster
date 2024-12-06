using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator animator;
    public void PlayGame()
    {
        //animator.SetTrigger("FadeOut");
        SceneManager.LoadSceneAsync(1);
    }
}

