using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickynoteREwrite : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _interactRange = 3f;
    [SerializeField] private GameObject intarcatableOb;

    private Ray playerAim;
  
    public float RayLength = 3f;
    public KeyCode interact;
    public KeyCode interact2;

    void Update()
    {
        
        if(Input.GetKeyDown(interact2))
                {
          //  intarcatableOb.GetComponent<StickyNote>().PlaceNoteWhereLooking();
            //
           //asdas TryInteract();
            Debug.Log("Interact called");

        }
        Ray playerAim = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(playerAim, out hit, RayLength))
        {
            if (hit.collider.gameObject.tag == "Sticky")
            {
                if (Input.GetKeyDown(interact)|| Input.GetKeyDown(interact2))
                {

                    TryInteract();
                    Debug.Log("Interact called");

                }

            // aasdaas

            }

            Debug.Log(hit.collider.gameObject.name);

        }
    }

    private void TryInteract()
    {
        
        intarcatableOb.GetComponent<StickyNote>().Interact();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TryInteract();
        Debug.Log("Interact called");
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name);
        this.gameObject.GetComponent<Material>().color = Color.blue;
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<Material>().color = Color.white;
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}