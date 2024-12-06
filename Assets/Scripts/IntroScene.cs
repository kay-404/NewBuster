using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroScene : MonoBehaviour
{
    public Animator animator;
    public void Day1Play()
    {
        //animator.SetTrigger("FadeOut");
        SceneManager.LoadSceneAsync(2);
    }
    

   
}
