using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public System.Action OnEnemyKilled;
    public float health = 100f;
    public float damage = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;

    private NavMeshAgent agent;
    private Transform player;
    private float lastAttackTime;

    private EnemyHealthUI enemyHealthUI;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        if (player == null) return;

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time - lastAttackTime > attackCooldown)
        {
            // Verificăm dacă playerul are scut
            PlayerEquipment eq = player.GetComponent<PlayerEquipment>();
            if (eq != null && eq.IsBlocking())
            {
                Debug.Log("🛡️ Scut activ – playerul NU ia damage!");
                return;
            }

            // Dacă nu are scut → dăm damage
            PlayerHealthBar1 ph = player.GetComponent<PlayerHealthBar1>();
            if (ph != null)
                ph.TakeDamage(damage);

            lastAttackTime = Time.time;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (enemyHealthUI != null)
            enemyHealthUI.Damage(amount);

        if (health <= 0f)
        {
            if (enemyHealthUI != null)
                enemyHealthUI.Hide();

            OnEnemyKilled?.Invoke(); // trimite notificare că a murit
            MoneyManager.Instance?.AddMoney(20);
            Destroy(gameObject);
        }
    }

    // Nou: primește UI-ul de la FightStarter
    public void SetHealthUI(EnemyHealthUI ui)
    {
        enemyHealthUI = ui;
        enemyHealthUI.gameObject.SetActive(true);
        enemyHealthUI.Show();
        enemyHealthUI.SetHealth(health);
    }
}