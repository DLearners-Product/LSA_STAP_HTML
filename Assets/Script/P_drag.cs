using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class P_drag : MonoBehaviour


{
    public bool lerp;
    public GameObject fill,Image,P_letter,selected;
    public Vector2 pos_initial;
    

    // Start is called before the first frame update
    void Start()
    {
        Image.SetActive(false);
        pos_initial = P_letter.transform.position;
    }

    void Update()
    {
        if(lerp)
        {
            Debug.Log("lerp");
            P_letter.transform.position = Vector2.Lerp (P_letter.transform.position,fill.transform.position, 3f*Time.deltaTime);
        }
    }

   public void lerping()
   {
        selected = EventSystem.current.currentSelectedGameObject;
        if (selected.name == "word")
        {
            Debug.Log("ok");
            lerp = true;
            Invoke("Imageappear", 2f);
        }
   }
   public void Imageappear()
   {
        
        Image.SetActive(true);
   }
    public void P_phonemic_reset()
    {
        P_letter.transform.position = pos_initial;
        Image.SetActive(false);
        lerp = false;
    }

}
