using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Demo1 : MonoBehaviour
{

    bool CorrectChange;
    int ChangeGiven;

    int PressTen;
    int PressFive;
    int PressOne;
    double PressQuarter;
    double PressNickel;
    double PressDime;
    double PressPenny;


    public TextMeshProUGUI ChangeGivenLabel;
     

    void Start()
    {
        PressTen = 10;
        PressFive = 5;
        PressOne = 1;
        PressQuarter = .25;
        PressNickel = .05;
        PressPenny = .01;
        PressDime = .10;

        if (ChangeGiven == 3.0)
        {
            CorrectChange = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
