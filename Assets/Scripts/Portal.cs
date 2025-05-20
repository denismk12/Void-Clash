using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool playerIsNear = false;

    // Referință la GameObject-ul UI cu textul de prompt
    public GameObject promptUI;

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);  // Ascunde textul la start
    }

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("ArenaScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            if (promptUI != null)
                promptUI.SetActive(true);  // Arată textul când jucătorul intră în portal
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            if (promptUI != null)
                promptUI.SetActive(false);  // Ascunde textul când jucătorul iese din portal
        }
    }
}