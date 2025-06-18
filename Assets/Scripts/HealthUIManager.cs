using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthUIManager : MonoBehaviour
{
    public static HealthUIManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // evită duplicate
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // păstrează între scene
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu") // numele exact al scenei de meniu
            gameObject.SetActive(false);  // ascunde HUD-ul
        else
            gameObject.SetActive(true);   // arată HUD-ul în joc
    }
}