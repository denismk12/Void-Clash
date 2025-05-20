using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            GameObject spawnPoint = GameObject.Find("PortalSpawnPoint");
            if (spawnPoint != null && playerPrefab != null)
            {
                Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
            else
            {
                Debug.LogError("PortalSpawnPoint sau playerPrefab nu este setat!");
            }
        }
    }
}