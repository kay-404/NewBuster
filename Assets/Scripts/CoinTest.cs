using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinTest : MonoBehaviour
{
    public Animator animator;
    public void NewCoinScreen()
    {
        //animator.SetTrigger("FadeOut");
        SceneManager.LoadSceneAsync(4);
    }
}


