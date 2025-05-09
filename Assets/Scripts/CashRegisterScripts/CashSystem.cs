using TMPro;
using UnityEngine;

public class CashSystem : MonoBehaviour
{
    public float money;
    public TMP_Text moneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 0;
        UpdateMoneyText();
    }

    public void addMoney(float moneyToAdd)
    {
        money += moneyToAdd;
        money = Mathf.Round(money * 100.0f) * 0.01f;
        UpdateMoneyText();
    }

    public void resetMoney()
    {
        money = 0;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        string tempString;

        tempString = string.Format("{0:C}", money);
        moneyText.SetText("Cashback Total: " + tempString);
    }
}
