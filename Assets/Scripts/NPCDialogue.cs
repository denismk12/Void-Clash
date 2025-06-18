using UnityEngine;
using TMPro;
using System.Collections;

public class NPCDialogue : MonoBehaviour
{
    public GameObject promptUI;         // "Apasă E să vorbești"
    public TextMeshProUGUI dialogueText;
    public string message = "Salut, războinicule!";
    private bool isPlayerNear = false;

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);

        if (dialogueText != null)
            dialogueText.text = "";
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueText != null)
                StartCoroutine(ShowMessage());
        }
    }

    IEnumerator ShowMessage()
    {
        if (promptUI != null)
            promptUI.SetActive(false);

        dialogueText.text = message;
        yield return new WaitForSeconds(3f);
        dialogueText.text = "";

        if (promptUI != null)
            promptUI.SetActive(true);
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
