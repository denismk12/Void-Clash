using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public TextMeshProUGUI moneyText;
    private int currentMoney = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    void UpdateMoneyUI()
    {
        if (moneyText != null)
            moneyText.text = $"Bani: {currentMoney}$";
    }

   
}