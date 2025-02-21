using UnityEngine;

public class D1_GameManager : MonoBehaviour
{
    void Start()
    {
        CharacterDataStorage.Instance.ResetCharacterApproval();
    }
}
