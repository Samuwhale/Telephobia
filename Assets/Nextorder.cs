using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextorder : MonoBehaviour
{
    public GameObject[] orders;
    public GameObject[] orderText;
    public int orderindex;
    // Start is called before the first frame update


    public void nextorder()
    {
        orders[orderindex].SetActive(false);
        orderindex = (orderindex + 1) % orders.Length;
        orders[orderindex].SetActive(true);
    }
    public void Prevorder()
    {
        orders[orderindex].SetActive(false);
        orderindex--;
        if (orderindex < 0)
        {
            orderindex += orders.Length;

        }
        orders[orderindex].SetActive(true);

    }

    public void orderselect(int N)
    {
        orderText[N].SetActive(true);
    }


}
