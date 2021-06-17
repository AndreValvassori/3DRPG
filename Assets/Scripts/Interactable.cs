
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
                Interact();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        //Debug.Log("Onfocused");
        //hasInteracted = true; // Removido. Não interage mais a longa distância.
        isFocus = true;
        Player = playerTransform;
    }

    public void OnDefocused()
    {
        //Debug.Log("OnDefocused");
        isFocus = false;
        Player = null;
        hasInteracted = false;
        StopInteract();
    }

    public void Interact()
    {
        //Ao interagir, o que fazer? Abrir menu, teleportar etc...
        Debug.Log("Interact");
    }

    public void StopInteract()
    {
        // Aqui, cancelar interação (Esconder menu, etc..)
        Debug.Log("StopInteract");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
