using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Drag_Bat : MonoBehaviour
{
    public bool B_drag;
    public GameObject G_fill;
    public Vector2 pos_initial;
    public bool B_corret;

    public AudioSource wrong;
    public AudioClip[] AUD_answers;
    public AudioSource AUD_source;

   

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == this.name)
        {
            B_corret = true;
         //   Debug.Log("1");
           // if (!B_drag)
            {
                B_drag = false;
             //   if (this.gameObject.tag == collision.gameObject.tag)
                {
                    this.transform.position = collision.gameObject.transform.position;
                    this.gameObject.GetComponent<Collider2D>().enabled = false;
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;
                    // this.transform.position
                   // this.GetComponent<Drag_Bat>().enabled = false;
                   // Debug.Log("ins!!!!!!!!");
                    batgame.OBJ_batgame.I_answercount++;
                    if (batgame.OBJ_batgame.B_gotanswer == false)
                    {
                        // batgame.OBJ_batgame.STR_1 = collision.gameObject.tag;
                        batgame.OBJ_batgame.STR_1 = this.gameObject.tag;
                        batgame.OBJ_batgame.B_gotanswer = true;
                    }
                    if (batgame.OBJ_batgame.I_answercount == 2)
                    {
                        
                        batgame.OBJ_batgame.G_ques.SetActive(false);
                       if (batgame.OBJ_batgame.STR_1 == "batgameanswer1")
                       // if (batgame.OBJ_batgame.STR_1 == this.gameObject.tag)
                        {
                            AUD_source.clip = AUD_answers[0];
                            AUD_source.Play();
                            batgame.OBJ_batgame.G_ans2.SetActive(true);

                            //Debug.Log("1st");
                            for (int i = 0; i < batgame.OBJ_batgame.GA_formSentence2.Length; i++)
                            {
                                batgame.OBJ_batgame.GA_formSentence2[i].SetActive(false);
                            }
                        }
                       //else
                       if (batgame.OBJ_batgame.STR_1 == "batgameanswer2")
                       {
                            {
                                AUD_source.clip = AUD_answers[1];
                                AUD_source.Play();
                                batgame.OBJ_batgame.G_ans1.SetActive(true);
                                Debug.Log("2nd");
                                for (int i = 0; i < batgame.OBJ_batgame.GA_formSentence2.Length; i++)
                                {
                                    batgame.OBJ_batgame.GA_formSentence2[i].SetActive(false);
                                }
                            }
                       }
                    }
                }
            }
        }

        else
        {
            wrong.Play();
            if (!B_drag && !B_corret)
            {
                
                this.transform.position = pos_initial;
                //Debug.Log("wrong anser intial posQ");
            }
        }

    }
}