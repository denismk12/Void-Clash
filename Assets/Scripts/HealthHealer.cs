using UnityEngine;
using TMPro;
using System.Collections;

public class HealthHealer : MonoBehaviour
{
    private bool isPlayerNear = false;

    public GameObject promptUI;           // HealPromptText
    public TextMeshProUGUI confirmText;   // HealCompleteText

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
        if (confirmText != null)
            confirmText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            PlayerHealthBar1 playerHealth = FindObjectOfType<PlayerHealthBar1>();
            if (playerHealth != null)
            {
                playerHealth.HealToFull();
                StartCoroutine(ShowConfirmation());
            }
        }
    }

    IEnumerator ShowConfirmation()
    {
        if (promptUI != null)
            promptUI.SetActive(false);

        if (confirmText != null)
        {
            confirmText.text = "Viața ta este încărcată la maxim";
            confirmText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            confirmText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (promptUI != null)
                promptUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (promptUI != null)
                promptUI.SetActive(false);
        }
    }
}