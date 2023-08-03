using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float attachDistance = 1.0f; // The distance at which the item will be attached

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that touched the item is a player or a similar object
        if (other.gameObject.CompareTag("Player"))
        {
            // Calculate the position where the item will be attached
            Vector3 attachPosition = new Vector3(-0.223000005f, 0.633999109f, 0.973999977f);

            // Make the item a child of the player object
            gameObject.transform.SetParent(other.transform);

            // Disable the item's collider so that it won't trigger the OnTriggerEnter method again
            gameObject.GetComponent<Collider>().enabled = false;
            transform.localPosition = attachPosition;
            transform.LookAt(-(other.transform.position + other.transform.forward));
            transform.rotation = new Quaternion(0,270,0, 0);
        }
    }
}
// Vector3(-0.223000005,0.633999109,0.973999977)