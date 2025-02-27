
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Rendering;
using Yarn.Unity;

public class CustomerEvents : MonoBehaviour
{
    public GameTime timeScript;
    public CashSystem gameMoney;
    public GameObject customer;
    public Image customerPortrait;
    //public GameObject vhs;
    public DialogueRunner customerEntranceDialog;
    public DialogueRunner customerExitDialog;
    
    public int arrivalTime;
    public float cashBackValue;
    public string entranceDialogText;
    public string exitDialogText;
    public bool hasTextStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customerPortrait.enabled = false;
        //vhs.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeScript.timeHours == arrivalTime)
        {
            //customer.GetComponent<SpriteRenderer>().enabled = true;
            customerPortrait.enabled=true;
            //vhs.GetComponent <SpriteRenderer>().enabled = true;
            if (hasTextStarted == false)
            {
                customerEntranceDialog.StartDialogue(entranceDialogText);
                hasTextStarted = true;
            }
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
