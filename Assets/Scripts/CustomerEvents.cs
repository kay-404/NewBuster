using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Yarn.Unity;

public class CustomerEvents : MonoBehaviour
{
    public GameTime timeScript;
    public CashSystem gameMoney;
    public GameObject customer;
    public GameObject vhs;
    public DialogueRunner customerEntranceDialog;
    public DialogueRunner customerExitDialog;
    
    public int arrivalTime;
    public float cashBackValue;
    public string entranceDialogText;
    public string exitDialogText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customer.GetComponent<SpriteRenderer>().enabled = false;
        vhs.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeScript.timeHours == arrivalTime)
        {
            customer.GetComponent<SpriteRenderer>().enabled = true;
            vhs.GetComponent <SpriteRenderer>().enabled = true;
            customerEntranceDialog.StartDialogue(entranceDialogText);
        }
    }

    public void Cashback()
    {
        if(gameMoney.money == cashBackValue)
        {
            customerExitDialog.StartDialogue(exitDialogText);
            gameMoney.money = 0;
        }
    }
}
