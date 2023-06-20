using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutuorialCalling : MonoBehaviour
{
    public string number = null;
    int numberIndex = 0;
    string num;
    public TMP_Text mynumber = null;

    public void numbfunction(string numbers)
    {
        if (numberIndex<=11)
        {
            numberIndex++;
            number = number + numbers;
            mynumber.text = number;
        }
       
       
    }
    public void deletenum()
    {
        numberIndex = 0; 
        while (mynumber.text.Length > 0)
        {
            mynumber.text = mynumber.text.Substring(0, mynumber.text.Length - 1);
            number = number.Substring(0, number.Length - 1);

           
        }
       
    }

}
