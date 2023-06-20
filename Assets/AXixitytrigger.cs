using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AXixitytrigger : MonoBehaviour
{
    public float work;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void AnixatiyVal(float N)
    {
        this.GetComponent<Image>().fillAmount += N/10;
    }

    public void workbones(float W)
    {
       
        float extra = work + W;
        score.GetComponent<TextMeshProUGUI>().text= "Score "+ extra.ToString(); 

        work += W;
        
        this.GetComponent<Image>().fillAmount += W / 10;


    }
}
