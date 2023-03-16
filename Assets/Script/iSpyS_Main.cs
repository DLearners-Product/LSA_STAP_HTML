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
	int totalAnsCount;
	public GameObject G_final;
	public AudioSource clapSource;
	public AudioClip clapClip;



	void Start()
	{
		blur.SetActive(false);
		answer_count = 0;
		totalAnsCount = 5;
		ScoreManager.instance.InstantiateScore(totalAnsCount);
	}


	public void Clicking()
	{
		selectedobj = EventSystem.current.currentSelectedGameObject;
		
		if (selectedobj.tag == "answer")
		{

			//selectedobj.GetComponent<Button>().enabled = false;	//TODO: Edited by emerson
			//Destroy(selectedobj.GetComponent<mouse>());		TODO: Edited by emerson

			if (selectedobj.name == "cissor" || selectedobj.name == "nake" || selectedobj.name == "trawberry" || selectedobj.name == "tar" || selectedobj.name == "unflower")
			{
				ScoreManager.instance.RightAnswer(answer_count, questionValue : selectedobj.name);
				answer_count++;
				count.text = ""+answer_count;
				selectedobj.SetActive(false);
				switch(selectedobj.name){
					case "cissor":
						G_1.SetActive(true);
						break;
					case "nake":
						G_2.SetActive(true);
						break;
					case "trawberry":
						G_3.SetActive(true);
						break;
					case "tar":
						G_4.SetActive(true);
						break;
					case "unflower":
						G_5.SetActive(true);
						break;
				}
				change();
			}else{
				ScoreManager.instance.WrongAnswer(answer_count);
			}
			// if (selectedobj.name == "nake")
			// {
			// 	answer_count++;
			// 	count.text = "" + answer_count;
			// 	selectedobj.SetActive(false);
			// 	G_2.SetActive(true);
			// 	change();
			// }
			// if (selectedobj.name == "trawberry")
			// {
			// 	answer_count++;
			// 	count.text = "" + answer_count;
			// 	selectedobj.SetActive(false);
			// 	G_3.SetActive(true);
			// 	change();
			// }
			// if (selectedobj.name == "tar")
			// {
			// 	answer_count++;
			// 	count.text = "" + answer_count;
			// 	selectedobj.SetActive(false);
			// 	G_4.SetActive(true);
			// 	change();
			// }
			// if (selectedobj.name == "unflower")
			// {
			// 	answer_count++;
			// 	count.text = "" + answer_count;
			// 	selectedobj.SetActive(false);
			// 	G_5.SetActive(true);
			// 	change();
			// }
			if(answer_count == totalAnsCount)
            {
				G_final.SetActive(true);
				clapSource.clip = clapClip;
				clapSource.Play();
            }
		}else{
			ScoreManager.instance.WrongAnswer(answer_count);
		}
		
	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			selectedobj = EventSystem.current.currentSelectedGameObject;
			// Debug.Log(selectedobj);
			// Debug.Log($"{selectedobj.name}", selectedobj);
			if(selectedobj == null || selectedobj.GetComponent<mouse>() == null){
				ScoreManager.instance.PlayerTried(answer_count);
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
