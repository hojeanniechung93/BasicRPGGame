using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

    //What do you want to do when you Interact, "virtual" allows it to be overwritten depending on the Interactable
    public virtual void Interact()
    {
        //This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    //Check if the player is close enough to the item to interact with it
    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position,interactionTransform.position);
            if (distance <= radius)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position,radius);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

}
