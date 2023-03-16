using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DragandDrop : MonoBehaviour
{
    public bool B_drag;
    public GameObject G_fill,G_dash;
    public Vector2 pos_initial;
    public bool B_corret;
    public AudioSource wrong;
    public AudioClip[] clips;

    public GameObject optionPanel; //T_Phonemic-1
    public GameObject[] otherOptions;  //T_Phonemic-1
    bool scoreSet;

    private void Start()
    {
        G_dash.SetActive(true);
        pos_initial = this.transform.position;
		ScoreManager.instance.InstantiateScore(1);
        scoreSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (B_drag)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousepos);
        }
        if(!B_drag && !B_corret)
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
        Debug.Log("collide");
        if (collision.gameObject.name == this.name)
        {
            this.transform.position = G_fill.transform.position;
            
            //Debug.Log()
            B_corret = true;
            Debug.Log("ans");
            if (!B_drag)
            {
                G_dash.SetActive(false);
                if(!scoreSet){
    				ScoreManager.instance.RightAnswer(0);
                    scoreSet = true;
                }

                this.GetComponent<DragandDrop>().enabled = false;
                if(this.name=="cat")
                {
                    wrong.clip = clips[0];
                    wrong.Play();
                }
                if (this.name == "pot")
                {
                    wrong.clip = clips[1];
                    wrong.Play();
                }
                optionPanel.SetActive(false);
                
                //for (int i = 0; i < otherOptions.Length; i++)
                //{
                //    otherOptions[i].SetActive(false);
                //}
                //if(optionPanel != null) optionPanel.GetComponent<Image>().enabled = false;
            }
        }
        else
        {
            if(!scoreSet){
    			ScoreManager.instance.WrongAnswer(0);
                scoreSet = true;
            }
           // int random = Random.Range(2, clips.Length);
            wrong.clip = clips[2];
            wrong.Play();
            B_corret = false;
            if (!B_drag)
            {
                
                this.transform.position = pos_initial;
                Debug.Log("wrong anser intial posQ");
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        B_corret = false;
        this.transform.position = pos_initial;
        scoreSet = false;
    }
}
