using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public RectTransform healthBarFill;
    private float maxHealth = 100f;
    private float currentHealth;
    private float fullWidth;

    void Start()
    {
        currentHealth = maxHealth;
        fullWidth = healthBarFill.sizeDelta.x;
        SetHealth(maxHealth);
        gameObject.SetActive(false); // ascuns la start
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetHealth(float value)
    {
        currentHealth = value;
        float ratio = currentHealth / maxHealth;
        healthBarFill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fullWidth * ratio);
    }

    public void Damage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        SetHealth(currentHealth);
    }
}