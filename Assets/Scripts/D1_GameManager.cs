using UnityEngine;

public class D1_GameManager : MonoBehaviour
{
    public static D1_GameManager Instance{get{return instance;}}
    private static D1_GameManager instance;
   
   void Awake()
   {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
   }
    void Start()
    {
        CharacterDataStorage.Instance.ResetCharacterApproval();
    }
}
