using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public Transform cam;
    public float playerActivateDistance;
    bool active = false;
    public GameObject[] dialogs;
    public int DN;
    public KeyCode keys;

    public float timer;
    public bool ringings;
    public bool callnumbers;


    private Ray playerAim;
    public Camera playerCam;
    public float RayLength = 3f;
    public KeyCode interact;
    public GameObject Numbertext;

    public GameObject ANIXITYBAR;
    public GameObject WorkYBAR;
    public GameObject Stressdialog;
    public GameObject prep;
    public void Update()
    {
        if (DN == 5 && timer <= 30)
        {
            Stressdialog.SetActive(true);
            prep.SetActive(true);
        }
        playerCam = Camera.main;
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(playerAim, out hit, RayLength))
        {
            if (hit.collider.gameObject.tag == "Phone" )
            {
                //if (Input.GetKeyDown(interact))
                //{
                //    if (callnumbers && ringings == false)
                //    {
                //        if ((Numbertext.GetComponent<TutuorialCalling>().number == this.GetComponent<phonenumbers>().Numbers[0].ToString() || Numbertext.GetComponent<TutuorialCalling>().number == this.GetComponent<phonenumbers>().Numbers[1].ToString()) && DN == 2)
                //        {

                //            dialogs[3].GetComponent<ConvoStarter>().startconvo();

                //        }
                //        else if (DN == 2) { dialogs[8].GetComponent<ConvoStarter>().startconvo(); }
                //        if (Numbertext.GetComponent<TutuorialCalling>().number == this.GetComponent<phonenumbers>().Numbers[2].ToString() && DN == 5)
                //        {
                //            dialogs[5].GetComponent<ConvoStarter>().startconvo();
                //        }
                //        else if (DN == 5) { dialogs[8].GetComponent<ConvoStarter>().startconvo(); }

                //    }
                //    else
                //    {
                //        dialogs[DN].GetComponent<ConvoStarter>().startconvo();
                //    }

                //    this.GetComponent<Animator>().SetBool("Ringing", false);
                //    ringings = false;
                //    this.GetComponent<AudioSource>().Stop();
                //}

              


            }

            Debug.Log(hit.collider.gameObject.name);

        }
            if (ringings)
        {
            timer -= 1*Time.deltaTime;
            if (timer <= 0)
            {
                phonerings();
                timer = 40;
            }
        }
       
        
    }
    public void cancall()
    {
        callnumbers = true;
    }
    public void cantcall()
    {
        callnumbers = false;
    }
    public void startconvo()
    {
        dialogs[DN].GetComponent<ConvoStarter>().startconvo();
        Stressdialog.SetActive(false);
        prep.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (callnumbers && ringings == false)
        {
            if ((Numbertext.GetComponent<TutuorialCalling>().number == this.GetComponent<phonenumbers>().Numbers[0].ToString()|| Numbertext.GetComponent<TutuorialCalling>().number == this.GetComponent<phonenumbers>().Numbers[1].ToString()) &&DN ==2)
            {
                WorkYBAR.GetComponent<AXixitytrigger>().workbones(2);
                dialogs[3].GetComponent<ConvoStarter>().startconvo();

            }else if(DN==2) { dialogs[8].GetComponent<ConvoStarter>().startconvo(); }
            if (Numbertext.GetComponent<TutuorialCalling>().number == this.GetComponent<phonenumbers>().Numbers[2].ToString()&&DN==5)
            {
                WorkYBAR.GetComponent<AXixitytrigger>().workbones(2);
                dialogs[5].GetComponent<ConvoStarter>().startconvo();
            }  else if(DN == 5) 
            {
              //  ANIXITYBAR.GetComponent<AXixitytrigger>().AnixatiyVal(2);
                dialogs[8].GetComponent<ConvoStarter>().startconvo();
            }
      
        }
        else
        {
           
            dialogs[DN].GetComponent<ConvoStarter>().startconvo();

           // WorkYBAR.GetComponent<AXixitytrigger>().workbones(2);
        }
       
        this.GetComponent<Animator>().SetBool("Ringing", false);
        ringings = false;
        this.GetComponent<AudioSource>().Stop();
      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name);
        touchphone();
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Animator>().SetBool("Pickup", false);
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
    public void Ringinging()
    {
        if (DN == 5 && timer <= 30)
        {
            Stressdialog.SetActive(true);
            prep.SetActive(true);
        }
        timer = 40;
        ringings = true;
    }
    public void phonerings()
    {
        if (DN==1 && DN==3)
        {

        }
        ANIXITYBAR.GetComponent<AXixitytrigger>().AnixatiyVal(2);
        this.GetComponent<Animator>().SetBool("Ringing",true);
        this.GetComponent<AudioSource>().Play();
    }
    public void touchphone()
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
        this.GetComponent<Animator>().SetBool("Pickup", true);
    }
    public void nextcovo()
    {
        DN += 1;
    }
}
