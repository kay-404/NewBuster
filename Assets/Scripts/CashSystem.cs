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
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.SetText("Cash: $" + money);
    }

    public void addMoney(float moneyToAdd)
    {
        money += moneyToAdd;
        money = Mathf.Round(money * 100.0f) * 0.01f;
    }

    public void resetMoney()
    {
        money = 0;
    }
}
