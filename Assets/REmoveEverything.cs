using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REmoveEverything : MonoBehaviour
{
    public GameObject[] all;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void remove()
    {
        all[0].SetActive(false);
        all[1].SetActive(false);
    }
}
