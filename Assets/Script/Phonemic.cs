using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Phonemic : MonoBehaviour
{
    
    public GameObject hide,selected;

    public GameObject answer;
    public Transform answerStartPos;
    public GameObject optionPanel; //T_Phonemic-1
    public GameObject[] otherOptions;

    public AudioClip AC_1, AC_2;
    public AudioSource AS_Empty;
   

    public int count = 0;

    public void Deletion()
    {
        selected = EventSystem.current.currentSelectedGameObject;
        if (selected.name == "Image")
        {
            count++;

            if (count % 2 == 0)
            {
                hide.SetActive(true);

            }
            else
            {
                hide.SetActive(false);
            }
        }
       
    }
   

    public void T_Phonemic_Reset()
    {
        answer.transform.position = answerStartPos.position;
        answer.GetComponent<DragandDrop>().enabled = true;

        for(int i = 0; i< otherOptions.Length; i++)
        {
            // optionPanel.GetComponent<Image>().enabled = true;
            optionPanel.SetActive(true);
            //otherOptions[i].SetActive(true);
        }
        hide.SetActive(true);
    }
}
