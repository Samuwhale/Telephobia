using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stickymouse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _interactRange = 3f;
    [SerializeField] private GameObject intarcatableOb ;

    private Ray playerAim;
    public Camera playerCam;
    public float RayLength = 3f;
    public KeyCode interact;
    

    void Update()
    {
        playerCam = Camera.main;
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(playerAim, out hit, RayLength))
        {
            //if (hit.collider.gameObject.tag == "Sticky")
            //{
            //    if (Input.GetKeyDown(interact))
            //    {

            //        TryInteract();
            //        Debug.Log("Interact called");

            //    }



            //}

            //Debug.Log(hit.collider.gameObject.name);

        }

    }

    private void TryInteract()
    {


        intarcatableOb.GetComponent<IInteractable>().Interact();



        
              
            
        
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
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}