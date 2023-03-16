using System;
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
	int totalAnsCount;

	public GameObject blur;
	public Text objname;

	//public GameObject lvlcmp;
	//public Text gem;

	public GameObject[] obj_Reset_color;
	public GameObject[] obj_Reset_grayscale;
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
			if (selectedobj.name == "en" || selectedobj.name == "ape" || selectedobj.name == "eddy" || selectedobj.name == "ent" || selectedobj.name == "iger")
			{
				ScoreManager.instance.RightAnswer(answer_count, questionValue : selectedobj.name);
				answer_count++;
				count.text = "" + answer_count;
				Debug.Log(selectedobj.name);
				selectedobj.SetActive(false);
				switch(selectedobj.name){
					case "en":
						G_1.SetActive(true);
						break;
					case "ape":
						G_2.SetActive(true);
						break;
					case "eddy":
						G_3.SetActive(true);
						break;
					case "ent":
						G_4.SetActive(true);
						break;
					case "iger":
						G_5.SetActive(true);
						break;
				}
				change();
			}else{
				Debug.Log("Came to inner else");
				ScoreManager.instance.WrongAnswer(answer_count);
			}
			// if (selectedobj.name == "ape")
			// {
			// 	answer_count++;
			// 	count.text = "" + answer_count;
			// 	selectedobj.SetActive(false);
			// 	G_2.SetActive(true);
			// 	change();
			// }
			// if (selectedobj.name == "eddy")
			// {
			// 	answer_count++;
			// 	count.text = "" + answer_count;
			// 	selectedobj.SetActive(false);
			// 	G_3.SetActive(true);
			// 	change();
			// }
			// if (selectedobj.name == "ent")
			// {
			// 	answer_count++;
			// 	count.text = "" + answer_count;
			// 	selectedobj.SetActive(false);
			// 	G_4.SetActive(true);
			// 	change();
			// }
			// if (selectedobj.name == "iger")
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
			Debug.Log("Came to outer else");
			ScoreManager.instance.WrongAnswer(answer_count);
		}		
   	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			selectedobj = EventSystem.current.currentSelectedGameObject;
			// Debug.Log(selectedobj);
			Button clickedObject;
			if(selectedobj == null || selectedobj.GetComponent<mouse>() == null){
				Debug.Log("If condition executed");
				ScoreManager.instance.PlayerTried(answer_count);
			}else if(selectedobj.TryGetComponent<Button>(out clickedObject)){
				Debug.Log($"{selectedobj.name}", selectedobj);

				Debug.Log(clickedObject.onClick.GetPersistentEventCount());
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