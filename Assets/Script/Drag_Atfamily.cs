using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Drag_Atfamily : MonoBehaviour
{
    public bool B_drag;
    public GameObject fill;
    public Vector2 pos_initial;
    public bool B_corret;

    //public AudioSource wrong;
  


    private void Start()
    {
        pos_initial = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (B_drag)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousepos);
        }
        if (!B_drag && !B_corret)
        {
            transform.position = pos_initial;
        }
    }

    void OnMouseDown()
    {
        B_drag = true;
    }
    void OnMouseUp()
    {

        B_drag = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //blackscreen.SetActive(false);
         Debug.Log("collide");
        if (this.name == "h")
        {
            if (!B_drag)
            {
                Debug.Log("trans");
                this.transform.position = fill.transform.position;
              //  blackscreen.SetActive(true);
               // this.gameObject.SetActive(false);
               // for (int j = 0; j < Atfamily.Length; j++)
               // {
               //     Atfamily[j].SetActive(false);
               // }
              //  Atfamily[0].SetActive(true);
            } 
        }
        
        else
        {
            
            if (!B_drag && !B_corret)
            {
                this.transform.position = pos_initial;
                Debug.Log("wrong anser intial posQ");
            }
        }
        
    }

    
}
