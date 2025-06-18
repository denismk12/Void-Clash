using UnityEngine;
using TMPro;
using System.Collections;

public class ArmorUpgrade : MonoBehaviour
{
    public int upgradeCost = 5;
    public int healthBonus = 5;

    public GameObject promptUI;
    public TextMeshProUGUI resultText;

    private bool isPlayerNear = false;

    void Start()
    {
        if (promptUI != null) promptUI.SetActive(false);
        if (resultText != null) resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            PlayerHealthBar1 ph = FindObjectOfType<PlayerHealthBar1>();

            if (ph != null && MoneyManager.Instance != null)
            {
                if (MoneyManager.Instance.GetCurrentMoney() >= upgradeCost)
                {
                    MoneyManager.Instance.AddMoney(-upgradeCost);
                    ph.IncreaseMaxHealth(healthBonus);
                    StartCoroutine(ShowResult("Armura ta a fost îmbunătățită!"));
                }
                else
                {
                    StartCoroutine(ShowResult("❌ Nu ai destui bani!"));
                }
            }
        }
    }

    IEnumerator ShowResult(string message)
    {
        if (promptUI != null) promptUI.SetActive(false);

        if (resultText != null)
        {
            resultText.text = message;
            resultText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            resultText.gameObject.SetActive(false);
            if (isPlayerNear && promptUI != null)
                promptUI.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (promptUI != null) promptUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (promptUI != null) promptUI.SetActive(false);
        }
    }
}