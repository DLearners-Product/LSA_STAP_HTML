using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batgame : MonoBehaviour
{
    public static batgame OBJ_batgame;
    public int I_answercount;
    public GameObject G_ans1, G_ans2, G_ques;
    public string STR_1=null;
    public bool B_gotanswer;

    public GameObject[] GA_formSentence2;
    public Transform hatpos,batpos;
    public GameObject Q1, Q2;


    public void Awake()
    {
        OBJ_batgame = this;
        B_gotanswer = false;
    }
    private void Start()
    {
    }


    public void BUT_formsentence02_Reset()
    {
        for(int i=0;i< GA_formSentence2.Length;i++)
        {
            GA_formSentence2[i].SetActive(true);
        }
        GA_formSentence2[0].transform.position = hatpos.position;
        GA_formSentence2[1].transform.position = batpos.position;
        I_answercount = 0;

        GA_formSentence2[0].GetComponent<Drag_Bat>().B_corret = false;
        GA_formSentence2[1].GetComponent<Drag_Bat>().B_corret = false;
        GA_formSentence2[0].GetComponent<Collider2D>().enabled = true;
        GA_formSentence2[1].GetComponent<Collider2D>().enabled = true;
        G_ans1.SetActive(false);
        G_ans2.SetActive(false);
        G_ques.SetActive(true);
        STR_1 = null;
        B_gotanswer = false;
        Q1.GetComponent<Collider2D>().enabled = true;
        Q2.GetComponent<Collider2D>().enabled = true;
    }

}
