using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Main_Selectcorrectobj : MonoBehaviour
{
    public string STR_gamename;
    public static Main_Selectcorrectobj OBJ_main_selectedcorrectobj;
    public GameObject selectedobj;
    public GameObject blur;
    //public Text objname;
    public int I_attempt;

    public GameObject G_block;
    public AudioClip[] wrongs;
    public AudioSource wrong;
    public AudioSource answer;
    public AudioClip answeClip;


    // Start is called before the first frame update
    void Start()
    {
        STR_gamename = this.gameObject.name;
        OBJ_main_selectedcorrectobj = this;
        G_block.SetActive(false);
        blur.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Clicking()
    {
        selectedobj = EventSystem.current.currentSelectedGameObject;

        if (selectedobj.tag == "answer")
        {

            //selectedobj.GetComponent<Button>().enabled = false;
            answer.clip = answeClip;
            answer.Play();
            //if (this.gameObject.GetComponent<AudioSource>() != null)
            //{
            //    this.GetComponent<AudioSource>().Play();
            //}
            change();

        }
        else
        {
            int random=Random.Range(0, wrongs.Length);
            wrong.clip = wrongs[random];
            wrong.Play();

            I_attempt++;
            THI_attmptForgame();
            /*if (this.gameObject.name == "S_Obj_Start")
            {
                Main_Blended.OBJ_main_blended.STRL_beginnings.Add(selectedobj.name);
            }
            if (this.gameObject.name == "A_Obj_Start")
            {
                Main_Blended.OBJ_main_blended.STRL_beginninga.Add(selectedobj.name);
            }
            if (this.gameObject.name == "T_Obj_Start")
            {
                Main_Blended.OBJ_main_blended.STRL_beginningt.Add(selectedobj.name);
            }
            if (this.gameObject.name == "P_Obj_Start")
            {
                Main_Blended.OBJ_main_blended.STRL_beginningp.Add(selectedobj.name);
            }
            if (this.gameObject.name == "T_Obj_End ")
            {
                Main_Blended.OBJ_main_blended.STRL_endtingt.Add(selectedobj.name);
            }
            if (this.gameObject.name == "P_Obj_End")
            {
                Main_Blended.OBJ_main_blended.STRL_endtingp.Add(selectedobj.name);
            }*/

        }
        

    }
    public void THI_attmptForgame()
    {
       /* if(Main_Blended.OBJ_main_blended.levelno==4)
        {
            Main_Blended.OBJ_main_blended.SobjectsStartWrongAttempt = I_attempt;
        }
        if (Main_Blended.OBJ_main_blended.levelno == 12)
        {
            Main_Blended.OBJ_main_blended.AobjectsStartWrongAttempt = I_attempt;
        }
        if (Main_Blended.OBJ_main_blended.levelno == 16)
        {
            Main_Blended.OBJ_main_blended.TobjectsStartWrongAttempt = I_attempt;
        }
        if (Main_Blended.OBJ_main_blended.levelno == 21)
        {
            Main_Blended.OBJ_main_blended.TobjectsEndWrongAttempt = I_attempt;
        }
        if (Main_Blended.OBJ_main_blended.levelno == 26)
        {
            Main_Blended.OBJ_main_blended.PobjectsEndStartAttempt = I_attempt;
        }
        if (Main_Blended.OBJ_main_blended.levelno == 27)
        {
            Main_Blended.OBJ_main_blended.PobjectsEndWrongAttempt = I_attempt;
        }*/
    }
    public void change()
    {
        blur.SetActive(true);
     //   objname.text = selectedobj.name;
        blur.transform.GetChild(0).GetComponent<Image>().sprite = selectedobj.GetComponent<Image>().sprite;
        blur.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
        Invoke("offblur", 2f);
        Debug.Log("blur!!");
    }
    public void offblur()
    {
        blur.SetActive(false);
        G_block.SetActive(true);
    }
}
