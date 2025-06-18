using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public RectTransform healthBarFill;

    public float maxHealth = 100f;
    private float currentHealth;

    private float fullWidth;

    void Start()
    {
        currentHealth = maxHealth;
        fullWidth = healthBarFill.sizeDelta.x;

        // simulăm damage pentru test
        InvokeRepeating(nameof(TestDamage), 1f, 1f);
    }

    void TestDamage()
    {
        TakeDamage(10f);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        float ratio = currentHealth / maxHealth;
        healthBarFill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fullWidth * ratio);
    }
}