using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar1 : MonoBehaviour
{
    public RectTransform healthBarFill;
    public float maxHealth = 100f;
    private float currentHealth;
    private float fullWidth;

    void Start()
    {
        currentHealth = maxHealth;
        fullWidth = healthBarFill.sizeDelta.x;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        float ratio = currentHealth / maxHealth;
        healthBarFill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fullWidth * ratio);

        Debug.Log($"HP actual: {currentHealth}/{maxHealth}");
    }

    // ✅ Nou: metodă pentru vindecare completă
    public void HealToFull()
    {
        currentHealth = maxHealth;
        float ratio = currentHealth / maxHealth;
        healthBarFill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fullWidth * ratio);

        Debug.Log("Viața a fost refăcută complet!");
    }

    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
        HealToFull();
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}