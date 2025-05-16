
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
    public TMP_Text customerID;
    public GameObject customerIdPhoto;
    public GameObject customer18Check;
    public SceneLoader sceneLoader;

    private bool isComplete = false;

    //public GameObject vhs;

    [Header("Dialogue GameObjects")]
    public DialogueRunner customerEntranceDialog;
    public DialogueRunner customerAngryDialog;
    public DialogueRunner customerExitDialog;

    [Header("Customer Data")]
    public string customerName;
    public bool over18;
    public bool isLastCustomer;

    public int arrivalTime;
    public int exitTime;
    public float cashBackValue;

    [Header("Customer Dialogue Start Nodes")]
    public string entranceDialogText;
    public string angryDialogText;
    public string exitDialogText;
    public bool hasTextStarted = false;
    public bool overBoxCollider = false;
    public bool arrived = false;
    public bool angry = false;
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
                CustomerID();
            }
        }

        if (timeScript.timeHours == exitTime)
        {
            if (isComplete == false)
            {
                if (angry == false)
                {
                    customerAngryDialog.StartDialogue(angryDialogText);
                    angry = true;
                    if (isLastCustomer == true)
                    {
                        sceneLoader.LoadScene();
                    }
                }
            }
        }
    }

    public void OnMouseOver()
    {
        overBoxCollider = true;
    }

    public void Timescore()
    {
        if(timeScript.timeHours == arrivalTime)
        {
            playerTimeScore.text = "Efficiency: A";
        }
        else
        {
            playerTimeScore.text = "Efficiency: C";
        }
    }

    public void CustomerID()
    {
        customerIdPhoto.SetActive(true);
        customerID.text = customerName;

        if (over18 == true)
        {
            customer18Check.SetActive(true);
        }
        else
        {
            customer18Check.SetActive(false);
        }
    }

    public void Cashback()
    {
        if (arrived == true)
        {
            if (gameMoney.money == cashBackValue)
            {
                isComplete = true;
                Timescore();
                customerExitDialog.StartDialogue(exitDialogText);
                customerIdPhoto.SetActive(false);
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
