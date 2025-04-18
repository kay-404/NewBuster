using UnityEngine;
using UnityEngine.Scripting;
using System.Collections.Generic;

public class CharacterDataStorage : MonoBehaviour
{
    [SerializeField] public List<CharacterSO> AllCharacters = new List<CharacterSO>();
    public static CharacterDataStorage Instance{get{return instance;}}
    private static CharacterDataStorage instance;
   
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

}
