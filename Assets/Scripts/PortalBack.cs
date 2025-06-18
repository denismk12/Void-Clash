using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBack : MonoBehaviour
{
    private bool playerIsNear = false;
    public GameObject promptUI;
    public string sceneToLoad = "Game"; // numele exact al scenei satului

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            if (promptUI != null)
                promptUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            if (promptUI != null)
                promptUI.SetActive(false);
        }
    }
}
