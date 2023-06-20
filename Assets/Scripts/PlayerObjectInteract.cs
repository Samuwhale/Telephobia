using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerObjectInteract : MonoBehaviour
{
    [SerializeField] private float _interactRange = 3f;


    [SerializeField] private string _interactButton = "Interact";
    [SerializeField] private string _altInteractButton = "AltInteract";


    void Update()
    {
        if (Input.GetButtonDown(_interactButton))
        {
            TryInteract();
            Debug.Log("Interact called");
        }
        else if (Input.GetButtonDown(_altInteractButton))
        {
            TryInteract(altInteract: true);
            Debug.Log("AltInteract called");
        }
    }

    private void TryInteract(bool altInteract = false)
    {
        Ray playerAim = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        if (Physics.Raycast(playerAim, out hit, _interactRange))
        {
            Debug.Log(hit);
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable == null) interactable = hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                if (altInteract)
                    interactable.AltInteract();
                else
                    interactable.Interact();
            }
        }
    }

}