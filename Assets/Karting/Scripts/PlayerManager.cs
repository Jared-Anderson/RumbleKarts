using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public BaseWeapon weapon;
    private Transform kartWeaponMount;
    private List<BaseWeapon> weapons = new List<BaseWeapon>();
    
    //Player ID
    private int playerID;

    [Header("Sub Behaviours")] public PlayerMovementBehaviour playerMovementBehaviour;

    [Header("Input Settings")]
    public PlayerInput playerInput;
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    void Start()
    {
        Transform childTransform = transform.Find("KartWeaponMount");

        if (childTransform != null)
        {
            // You can now use the childTransform reference
            kartWeaponMount = childTransform;
        }
        else
        {
            Debug.LogWarning("Child GameObject not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupItem(BaseWeapon weapon)
    {
        Debug.Log("Item picked up!");
        this.weapon = weapon;
        hasItem = true;
        UseItem();
    }

    public void DropItem() {
        weapon = null;
        hasItem = false;
    }

    public void UseItem() {
        weapon.Fire();
    }
    public Transform GetKartWeaponMount()
    {
        if (kartWeaponMount == null)
        {
            kartWeaponMount = transform.Find("KartVisual/Kart/Root/KartBase/KartWeaponMount");
        }
        return kartWeaponMount;
    }

    // Method to attach a weapon to the player's KartWeaponMount
    public void AttachWeapon(BaseWeapon weapon)
    {
        weapons.Add(weapon);
        // Optionally, you can handle equipping or using the weapon here
    }
}
