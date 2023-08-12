using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager playerManager = other.GetComponent<PlayerManager>();

            if (playerManager != null)
            {
                Transform weaponMount = playerManager.GetKartWeaponMount();
                Debug.Log(weaponMount);
                if (weaponMount != null)
                {
                    // Parent the item GameObject to the KartWeaponMount
                    transform.SetParent(weaponMount);

                    // Reset local position and rotation to keep the item's appearance
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.identity;

                    // Optionally, you can disable the item's collider or renderer
                    // to make it appear as attached to the player
                    Collider itemCollider = GetComponent<Collider>();
                    if (itemCollider != null)
                        itemCollider.enabled = false;

                    Renderer itemRenderer = GetComponent<Renderer>();
                    if (itemRenderer != null)
                        itemRenderer.enabled = false;

                    // Optionally, you can also keep a reference to the attached weapon
                    playerManager.AttachWeapon(GetComponent<BaseWeapon>());
                }
            }
        }
    }
}
