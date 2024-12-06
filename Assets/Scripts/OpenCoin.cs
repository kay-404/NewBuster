using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCoin : MonoBehaviour
{
    public Animator animator;
    public void OpenCoinScreen()
    {
        //animator.SetTrigger("FadeOut");
        SceneManager.LoadSceneAsync(3);
    }
}


