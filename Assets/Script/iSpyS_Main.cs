using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class iSpyS_Main: MonoBehaviour {

	[HideInInspector]
	public GameObject selectedobj;
	

	public GameObject obj1,obj2,obj3,obj4,obj5;
	public GameObject G_1, G_2, G_3, G_4, G_5;

	public GameObject[] obj_Reset_color;
	public GameObject[] obj_Reset_grayscale;
	
	public GameObject blur;
	public Text objname;
	public Text count;
	public int answer_count;
	public GameObject G_final;
	public AudioSource clapSource;
	public AudioClip clapClip;



	void Start()
	{
		blur.SetActive(false);
		answer_count = 0;
	}


	public void Clicking()
	{
		selectedobj = EventSystem.current.currentSelectedGameObject;
		
		if (selectedobj.tag == "answer")
		{

			//selectedobj.GetComponent<Button>().enabled = false;	//TODO: Edited by emerson
			//Destroy(selectedobj.GetComponent<mouse>());		TODO: Edited by emerson

			if (selectedobj.name == "cissor")
			{
				answer_count++;
				count.text = ""+answer_count;
				Debug.Log("coming sicore");
				selectedobj.SetActive(false);
				G_1.SetActive(true);
				change();
			}
			if (selectedobj.name == "nake")
			{
				answer_count++;
				count.text = "" + answer_count;
				selectedobj.SetActive(false);
				G_2.SetActive(true);
				change();
			}
			if (selectedobj.name == "trawberry")
			{
				answer_count++;
				count.text = "" + answer_count;
				selectedobj.SetActive(false);
				G_3.SetActive(true);
				change();
			}
			if (selectedobj.name == "tar")
			{
				answer_count++;
				count.text = "" + answer_count;
				selectedobj.SetActive(false);
				G_4.SetActive(true);
				change();
			}
			if (selectedobj.name == "unflower")
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
				clapSource.clip = clapClip;
				clapSource.Play();
            }
		}
		
	}

	public void change()
	{
		blur.SetActive(true);
		objname.text = selectedobj.name;
		blur.transform.GetChild(0).GetComponent<Image>().sprite = selectedobj.GetComponent<Image>().sprite;
		blur.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
		Invoke("offblur", 2f);
		Debug.Log("blur!!");
	}
	public void offblur()
	{
		blur.SetActive(false);
	}


	public void S_ISpy_Reset()
    {
		for(int i = 0; i< obj_Reset_color.Length; i++)
        {
			obj_Reset_color[i].SetActive(true);
			obj_Reset_grayscale[i].SetActive(false);
			answer_count = 0;
			count.text = "" + answer_count;
		}
	}
}
