using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Image[] slotImages = new Image[3];
    private Color[] originalColors;
    private int selectedSlot = -1;

    void Start()
    {
        // Salvăm culoarea originală (inclusiv alpha)
        originalColors = new Color[slotImages.Length];
        for (int i = 0; i < slotImages.Length; i++)
        {
            originalColors[i] = slotImages[i].color;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectSlot(2);
    }

    void SelectSlot(int index)
    {
        if (index < 0 || index >= slotImages.Length)
            return;

        selectedSlot = index;

        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i == index)
            {
                // Evidențiază slotul (mai luminos)
                Color baseColor = originalColors[i];
                slotImages[i].color = baseColor * 1.5f; // luminează culoarea
                slotImages[i].color = new Color(slotImages[i].color.r, slotImages[i].color.g, slotImages[i].color.b, baseColor.a); // păstrează alpha exact
            }
            else
            {
                // Revine la culoarea originală
                slotImages[i].color = originalColors[i];
            }
        }
    }
}