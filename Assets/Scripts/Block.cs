using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{  
    //Fields
    public int row;
    public int col;
    public bool isVisible;

    private void Start()
    {
        SetVisibility();
    }

    public void ONCLICK()
    {

        if (isVisible)
        {
            isVisible = false;
            this.transform.GetComponent<Image>().enabled = false;
        }
        else
        {
            isVisible = true;
            this.transform.GetComponent<Image>().enabled = true;
        }
    }

    public void SetVisibility()
    {
        if (isVisible)
        {
            this.transform.GetComponent<Image>().enabled = true;
        }
        else
        {
            this.transform.GetComponent<Image>().enabled = false;
        }
    }

   
}
