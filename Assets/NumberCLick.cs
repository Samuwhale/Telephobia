using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberCLick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject maincall;

    public string fill;


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
            if (hit.collider.gameObject.tag == "Num")
            {
                

               

            }

            Debug.Log(hit.collider.gameObject.name);

        }
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        maincall.GetComponent<TutuorialCalling>().numbfunction(fill);
        this.GetComponent<AudioSource>().Play();
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