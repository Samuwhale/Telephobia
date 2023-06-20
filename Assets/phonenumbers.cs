using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phonenumbers : MonoBehaviour
{
    public string[] Numbers;
    public GameObject Numbertext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callthistutorial()
    {
        if (Numbers[0] == Numbertext.GetComponent<TutuorialCalling>().number)
        {

        }
    }




}
