using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deletclick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject maincall;
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
            if (hit.collider.gameObject.tag == "Delete")
            {
                //if (Input.GetKeyDown(interact))
                //{
                //    maincall.GetComponent<TutuorialCalling>().deletenum();
                   
                //}

                //touch();

            }
         
            Debug.Log(hit.collider.gameObject.name);

        }

    }

    public void touch()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        maincall.GetComponent<TutuorialCalling>().deletenum();
        Debug.Log("Interact called");

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Interact called");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name);
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
