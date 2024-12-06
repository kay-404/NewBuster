using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public Animator animator;
    public void Restart()
    {
        //animator.SetTrigger("FadeOut");
        SceneManager.LoadSceneAsync(0);
    }
}


