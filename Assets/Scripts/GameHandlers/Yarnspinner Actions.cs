using UnityEngine;
using Yarn.Unity;

public class YarnspinnerActions : MonoBehaviour
{
    public GameObject thisObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("SetActive")]
    public void EnableGameObject(bool isEnabled)
    {
        thisObject.SetActive(isEnabled);
    } 
}
