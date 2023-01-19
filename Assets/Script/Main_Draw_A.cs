using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main_Draw_A : MonoBehaviour
{
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    public GameObject F1;
    public GameObject[] letter;
    public GameObject[] number;
    public int count;
    public  bool B_restart;
    // public bool first,second;
    public AudioSource sound;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        number[0].SetActive(true);
        number[1].SetActive(true);
        count = 1;
        B_restart = false;
    }
    public void restart_a()
    {
        for (int i = 0; i < number.Length; i++)
        {
            number[i].SetActive(false);
            number[i].GetComponent<CircleCollider2D>().enabled = true;
        }
        for (int i = 0; i < letter.Length; i++)
        {
            letter[i].SetActive(false);
        }
        number[0].SetActive(true);
        number[1].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            F1.transform.position = (mousePosition);
            B_restart = false;
        }  
        if(Input.GetMouseButtonUp(0))
        {
            restart();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "S_letter")
        {
            restart();
        }
    }

    public void restart()
    {
        B_restart = true;
        if (count==1)
        {
            number[1].SetActive(true);
            number[0].GetComponent<CircleCollider2D>().enabled = true;
            Debug.Log(" restrt coout = " + count);
        }
        if (count == 2)
        {
            //number[3].SetActive(false);
            number[2].GetComponent<CircleCollider2D>().enabled = true;
        }
        if (count == 3)
        {
           // number[4].SetActive(false);
            if(count>3)
            count = count - 1;
            number[3].GetComponent<CircleCollider2D>().enabled = true;
        }
        if (count == 4)
        {
            //number[5].SetActive(false);
            if (count > 4)
                count = count - 1;
            number[4].GetComponent<CircleCollider2D>().enabled = true; 
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!B_restart)
        {

            if (collision.gameObject.name == "1")
            {
                sound.Play();
                Debug.Log(" enter coout = " + count);
                //number[1].SetActive(true);
                collision.GetComponent<CircleCollider2D>().enabled = false;
            }

            if (collision.gameObject.name == "2")
            {
                sound.Play();
                Debug.Log("2");
                letter[0].SetActive(true);
                count++;
                Debug.Log("count = " + count);
                collision.GetComponent<CircleCollider2D>().enabled = false;
                number[2].SetActive(true);
     

            }
            if (collision.gameObject.name == "3")
            {
                sound.Play();
                //Debug.Log("3");
                number[3].SetActive(true);
                letter[1].SetActive(true);
                collision.GetComponent<CircleCollider2D>().enabled = false;
            }
            if (collision.gameObject.name == "4")
            {
                sound.Play();
                //Debug.Log("4");
                letter[2].SetActive(true);
                number[4].SetActive(true);
                
                collision.GetComponent<CircleCollider2D>().enabled = false;
                if (count == 2)
                {
                    count++;
                    Debug.Log("count=" + count);
                }
            }
            if (collision.gameObject.name == "5")
            {
                sound.Play();
                // Debug.Log("5");
                letter[3].SetActive(true);
                number[5].SetActive(true);
                if (count == 3)
                {
                    count++;
                    Debug.Log("count=" + count);
                }
                collision.GetComponent<CircleCollider2D>().enabled = false;
            }
            if (collision.gameObject.name == "6")
            {
                sound.Play();
                // Debug.Log("5");
                letter[4].SetActive(true);
                //number[5].SetActive(true);
                if (count == 3)
                {
                    count++;
                    Debug.Log("count=" + count);
                }
                collision.GetComponent<CircleCollider2D>().enabled = false;
            }


        }
    }
}
