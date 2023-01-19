using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MultipleDrag : MonoBehaviour
{
    public bool B_drag;
    public GameObject G_fill;
    public Vector2 pos_initial;
   public bool B_corret;
    public bool B_matched;
   public bool B_CorrectAnswer;

    public AudioSource wrong;
    public AudioClip[] answerclips;
    public AudioSource ansSource;

    private void Start()
    {
        pos_initial = this.transform.position;
        B_matched = false;
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
      
        if (collision.gameObject.name == this.name)
        {
            B_corret = true;
          //  Debug.Log("1");
          //  if (!B_drag)
            {
                B_drag = false;

                this.transform.SetParent(at_family_main.OBJ_at_family_main.Q_text.transform, false);
              //  Debug.Log("drag1");
                this.transform.position = G_fill.transform.position;
                Debug.Log("correct match!!!!!!");
                at_family_main.OBJ_at_family_main.GL_addedObjects.Add(this.gameObject);
                // this.transform.position
                // this.GetComponent<MultipleDrag>().enabled = false;

                Destroy(this.GetComponent<Collider2D>());
                Debug.Log("collider destro!");
                B_CorrectAnswer = true;
                if (at_family_main.OBJ_at_family_main.gamename == "form scenetance 1")
                {
                    if (at_family_main.OBJ_at_family_main.dash_count_S1 == 3)
                    {
                        ansSource.clip = answerclips[0];
                        ansSource.Play();
                        at_family_main.OBJ_at_family_main.Q_text.SetActive(false);
                        at_family_main.OBJ_at_family_main.A_text.SetActive(true);

                        for (int i = 0; i < at_family_main.OBJ_at_family_main.AllOption.Length; i++)
                        {
                            at_family_main.OBJ_at_family_main.AllOption[i].SetActive(false);
                        }

                    }
                }
                if (at_family_main.OBJ_at_family_main.gamename == "form scenetance 3")
                {
                    if (at_family_main.OBJ_at_family_main.dash_count_S3 == 2)
                    {
                        ansSource.clip = answerclips[1];
                        ansSource.Play();
                        at_family_main.OBJ_at_family_main.Q_text.SetActive(false);
                        at_family_main.OBJ_at_family_main.A_text.SetActive(true);


                        for (int i = 0; i < at_family_main.OBJ_at_family_main.AllOption.Length; i++)
                        {
                            at_family_main.OBJ_at_family_main.AllOption[i].SetActive(false);
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
                Debug.Log("wrong anser intial posQ");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == this.name)
        {
            if (!B_matched)
            {
                B_matched = true;
                if (at_family_main.OBJ_at_family_main.gamename == "form scenetance 1")

                {
                    at_family_main.OBJ_at_family_main.dash_count_S1++;
                   
                }
                if (at_family_main.OBJ_at_family_main.gamename == "form scenetance 3")
                {
                    at_family_main.OBJ_at_family_main.dash_count_S3++;
                   
                }

            }
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    //if (collision.gameObject.name == this.gameObject.name && B_matched && B_corret)
    //    // {
    //    if (B_CorrectAnswer == true)
    //    {
    //       // B_corret = false;
    //        this.gameObject.transform.position = G_fill.transform.position;
    //        Debug.Log("exit!");
    //    }//   Debug.Log("exit!");
    //     // B_matched = false;
    //     //  B_corret = false;
    //    B_corret = false;
       
    //    //}
    //}
}
