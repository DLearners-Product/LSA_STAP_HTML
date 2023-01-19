﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class iSpyT_Main: MonoBehaviour {

	[HideInInspector]public GameObject selectedobj;
	

	//public bool lerp,lerp1;
	public GameObject obj1,obj2,obj3,obj4,obj5;
	public GameObject G_1, G_2, G_3, G_4, G_5;

	public Text count;
	public int answer_count;


	public GameObject blur;
	public Text objname;

	//public GameObject lvlcmp;
	//public Text gem;

	public GameObject[] obj_Reset_color;
	public GameObject[] obj_Reset_grayscale;
	public GameObject G_final;


	void Start()
	{
		blur.SetActive(false);
		answer_count = 0;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
    public void change()
    {
		blur.SetActive(true);
		objname.text = selectedobj.name;
		blur.transform.GetChild(0).GetComponent<Image>().sprite = selectedobj.GetComponent<Image>().sprite;
		blur.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
		Invoke("offblur", 2f);

	}

    public void Clicking()
   {
		selectedobj = EventSystem.current.currentSelectedGameObject;
		//Debug.Log(selectedobj.tag);
		
		
	    if (selectedobj.tag == "answer")
		{

			//selectedobj.GetComponent<Button>().enabled = false;	//TODO: Edited by emerson
			//Destroy(selectedobj.GetComponent<mouse>());

			if (selectedobj.name == "en")
			{
				answer_count++;
				count.text = "" + answer_count;
				Debug.Log(selectedobj.name);
				selectedobj.SetActive(false);
				G_1.SetActive(true);
				change();

			}
			if (selectedobj.name == "ape")
			{
				answer_count++;
				count.text = "" + answer_count;
				selectedobj.SetActive(false);
				G_2.SetActive(true);
				change();
			}
			if (selectedobj.name == "eddy")
			{
				answer_count++;
				count.text = "" + answer_count;
				selectedobj.SetActive(false);
				G_3.SetActive(true);
				change();
			}
			if (selectedobj.name == "ent")
			{
				answer_count++;
				count.text = "" + answer_count;
				selectedobj.SetActive(false);
				G_4.SetActive(true);
				change();
			}
			if (selectedobj.name == "iger")
			{
				answer_count++;
				count.text = "" + answer_count;
				selectedobj.SetActive(false);
				G_5.SetActive(true);
				change();
			}

			if(answer_count == 5)
            {
				G_final.SetActive(true);
            }

		
		}
		
   }
	public void offblur()
    {
		blur.SetActive(false);
		//lerp = false;
    }

	public void T_ISpy_Reset()
	{
		for (int i = 0; i < obj_Reset_color.Length; i++)
		{
			obj_Reset_color[i].SetActive(true);
			obj_Reset_grayscale[i].SetActive(false);
			answer_count = 0;
			count.text = "" + answer_count;
		}
	}
}