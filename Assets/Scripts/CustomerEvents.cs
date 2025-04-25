
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.Rendering;
using Yarn.Unity;

public class CustomerEvents : MonoBehaviour
{
    public GameTime timeScript;
    public CashSystem gameMoney;
    public GameObject customer;
    public GameObject errorMessage;
    public Image customerPortrait;
    public TMP_Text playerTimeScore;

    //public GameObject vhs;
    public DialogueRunner customerEntranceDialog;
    public DialogueRunner customerExitDialog;
    
    public int arrivalTime;
    public float cashBackValue;
    public string entranceDialogText;
    public string exitDialogText;
    public bool hasTextStarted = false;
    public bool arrived = false;
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
                arrived = true;
            }
        }
    }

    public void Timescore()
    {
        if(timeScript.timeHours == arrivalTime)
        {
            playerTimeScore.text = "Efficiency: A";
        }
        else
        {
            playerTimeScore.text = "Efficiency: F";
        }
    }

    public void Cashback()
    {
        if (arrived == true)
        {
            if (gameMoney.money == cashBackValue)
            {
                Timescore();
                customerExitDialog.StartDialogue(exitDialogText);
                arrived=false;
                gameMoney.money = 0;
            }
            else
            {
                errorMessage.SetActive(true);
                gameMoney.money = 0;
            }
        }
    }
}
