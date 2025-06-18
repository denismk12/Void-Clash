using UnityEngine;

public class FightStarter : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public EnemyHealthUI enemyHealthUI;

    private bool isPlayerNear = false;
    private bool fightInProgress = false;

    private int waveCount = 0;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !fightInProgress)
        {
            fightInProgress = true;

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            EnemyAI ai = enemy.GetComponent<EnemyAI>();

            if (ai != null)
            {
                int bonusHealth = 100 + (waveCount * 20);
                ai.health = bonusHealth;
                ai.SetHealthUI(enemyHealthUI);
                ai.OnEnemyKilled += HandleEnemyKilled;
                Debug.Log($"⚔️ Spawnat Inamic cu {bonusHealth} HP (Wave {waveCount + 1})");
            }
        }
    }

    private void HandleEnemyKilled()
    {
        fightInProgress = false;
        waveCount++;
        Debug.Log("☠️ Inamic eliminat! Poți începe următoarea rundă.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}