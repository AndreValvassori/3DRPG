
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    bool isFocus = false;
    Transform Player;

    bool hasInteracted = false;

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(Player.position, transform.position);
            if (distance <= radius)
            {
                hasInteracted = true;
                Debug.Log("Interact");
            }

        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        Player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        Player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
