using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Image[] slotImages = new Image[3];
    private Color[] originalColors;
    private int selectedSlot = -1;

    void Awake()
    {
        // Previne duplicatele la schimbarea scenelor
        InventoryManager[] existingManagers = FindObjectsOfType<InventoryManager>();
        if (existingManagers.Length > 1)
        {
            Destroy(gameObject); // distruge dacă deja există unul
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

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

        // DEBUG: verifică dacă meniul e activ
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("InventoryManager activ? " + gameObject.activeInHierarchy);
        }
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
                Color baseColor = originalColors[i];
                slotImages[i].color = baseColor * 1.5f;
                slotImages[i].color = new Color(slotImages[i].color.r, slotImages[i].color.g, slotImages[i].color.b, baseColor.a);
            }
            else
            {
                slotImages[i].color = originalColors[i];
            }
        }
    }
}