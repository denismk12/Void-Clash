using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public LayerMask enemyLayer;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse stânga
        {
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // centru ecranului
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
            {
                EnemyAI enemy = hit.collider.GetComponent<EnemyAI>();
                if (enemy != null)
                {
                    PlayerEquipment eq = GetComponent<PlayerEquipment>();
                    int dmg = eq != null ? eq.GetCurrentDamage() : 10;
                    enemy.TakeDamage(dmg);
                    Debug.Log("Lovitură reușită!");
                }
            }
        }
    }
}