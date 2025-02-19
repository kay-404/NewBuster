using UnityEngine;

public class AddMoney : MonoBehaviour
{
    public GameObject cashRegister;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OneCent()
    {
        cashRegister.GetComponent<CashSystem>().addMoney(0.01f);
    }

    public void FiveCents()
    {
        cashRegister.GetComponent<CashSystem>().addMoney(0.5f);
    }

    public void TenCents()
    {
        cashRegister.GetComponent<CashSystem>().addMoney(0.1f);
    }

    public void TwentyfiveCents()
    {
        cashRegister.GetComponent<CashSystem>().addMoney(0.25f);
    }

    public void OneDollar()
    {
        cashRegister.GetComponent<CashSystem>().addMoney(1);
    }

    public void FiveDollars()
    {
        cashRegister.GetComponent<CashSystem>().addMoney(5);
    }

    public void TenDollars()
    {
        cashRegister.GetComponent<CashSystem>().addMoney(10);
    }
}
