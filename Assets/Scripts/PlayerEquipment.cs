using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public GameObject weaponFist;
    public GameObject weaponSword;
    public GameObject weaponShield;
    public int swordBonusDamage = 0;

    public enum WeaponType { Fist, Sword, Shield }
    public WeaponType equippedWeapon = WeaponType.Fist;

    private static PlayerEquipment instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        EquipWeapon(WeaponType.Fist); // echipat default
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(WeaponType.Fist);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(WeaponType.Sword);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipWeapon(WeaponType.Shield);
    }

    public void EquipWeapon(WeaponType type)
    {
        equippedWeapon = type;

        weaponFist.SetActive(type == WeaponType.Fist);
        weaponSword.SetActive(type == WeaponType.Sword);
        weaponShield.SetActive(type == WeaponType.Shield);

        Debug.Log("Echipat: " + type);
    }

    public int GetCurrentDamage()
    {
        if (equippedWeapon == WeaponType.Fist) return 10;
        if (equippedWeapon == WeaponType.Sword) return 20 + swordBonusDamage;
        return 0;
    }

    public bool IsBlocking()
    {
        return equippedWeapon == WeaponType.Shield;
    }

    public void IncreaseSwordDamage(int amount)
    {
        swordBonusDamage += amount;
    }
}