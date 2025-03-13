using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Debug.Log("Spider tried enter safe zone");

            Destroy(other.gameObject);
        }
    }
}
