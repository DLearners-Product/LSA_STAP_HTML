using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Atfamily_Main : MonoBehaviour
{
    //public GameObject blackscreen;
    public GameObject[] At, I_at, At_pos, I_pos;
    public GameObject h, c, s, m, b, f;
    public GameObject fill;
    public bool B_drag;
    public AudioClip[] atfamily;
    public AudioSource Music;

    public int i, k;

    // Start is called before the first frame update
    void Start()
    {

        for (int j = 0; j < At.Length; j++)
        {
            At_pos[j].SetActive(false);
            I_pos[j].SetActive(false);
        }
        k = -1;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        for (int j = 0; j < At.Length; j++)
        {
            At[j].SetActive(false);
        }

        //blackscreen.SetActive(false);
        Debug.Log("collide");
        if (collision.gameObject.name == "h")
        {
            Debug.Log("Hat");
            h.transform.position = fill.transform.position;
            i = 0;
            h.gameObject.SetActive(false);
            Destroyobj();
        }
        if (collision.gameObject.name == "c")
        {
            Debug.Log("Cat");
            c.transform.position = this.transform.position;
            i = 1;
            c.gameObject.SetActive(false);
            Destroyobj();

        }
        if (collision.gameObject.name == "s")
        {
            Debug.Log("Sat");
            s.transform.position = this.transform.position;
            s.gameObject.SetActive(false);
            i = 2;
            Destroyobj();

        }
        if (collision.gameObject.name == "m")
        {
            Debug.Log("Mat");
            m.transform.position = this.transform.position;
            m.gameObject.SetActive(false);
            i = 3;
            Destroyobj();

        }
        if (collision.gameObject.name == "b")
        {
            Debug.Log("Bat");
            b.transform.position = this.transform.position;
            b.gameObject.SetActive(false);
            i = 4;
            Destroyobj();

        }
        if (collision.gameObject.name == "f")
        {
            Debug.Log("Fat");
            f.transform.position = this.transform.position;
            f.gameObject.SetActive(false);
            i = 5;
            Destroyobj();

        }


    }
    public void Destroyobj()
    {
        Music.clip = atfamily[i];
        Music.Play();
        this.gameObject.SetActive(false);
        At[i].SetActive(true);
        I_at[i].SetActive(true);
        Invoke("Swap", 2f);
    }
    public void Swap()
    {
        k++;
        At_pos[k].SetActive(true);
        At_pos[k].transform.GetChild(0).GetComponent<Image>().sprite = At[i].GetComponent<Image>().sprite;
        At_pos[k].transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
        I_pos[k].SetActive(true);
        I_pos[k].transform.GetChild(0).GetComponent<Image>().sprite = I_at[i].GetComponent<Image>().sprite;
        I_pos[k].transform.GetChild(0).GetComponent<Image>().preserveAspect = true;

        if (k < 5)
        {
            this.gameObject.SetActive(true);
        }
        else
        { this.gameObject.SetActive(false); }


        At[i].SetActive(false);
        I_at[i].SetActive(false);



    }


    public void at_familyWords_Reset()
    {
        for (int j = 0; j < At.Length; j++)
        {
            At_pos[j].SetActive(false);
            I_pos[j].SetActive(false);
            this.gameObject.SetActive(true);
        }

        h.SetActive(true);
        c.SetActive(true);
        s.SetActive(true);
        m.SetActive(true);
        b.SetActive(true);
        f.SetActive(true);

        k = -1;
    }
}