using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class at_family_main : MonoBehaviour
{
    public string gamename;
    public int dash_count_S1,dash_count_S3;
    public static at_family_main OBJ_at_family_main;
    public GameObject Q_text,A_text;

    public List<GameObject> GL_addedObjects;


    public GameObject[] AllOption;
    public Transform[] AllOptionPos;
    public GameObject[] BackTo_QuesAns; //  0 question  1 answer

          //to turn on the collider when restart

    // Start is called before the first frame update
    void Start()
    {
        OBJ_at_family_main = this;
        A_text.SetActive(false);
    }

    public void form_sentence_Reset()
    {
        Debug.Log("form_sentence_reset");
        for (int j = 0; j < GL_addedObjects.Count; j++)
        {
            GL_addedObjects[j].transform.SetParent(this.transform.GetChild(0).transform, false);
        }
        GL_addedObjects = new List<GameObject>();

        for (int i = 0; i < AllOption.Length; i++)
        {
            AllOption[i].transform.position = AllOptionPos[i].position;
            if (AllOption[i].GetComponent<BoxCollider2D>() == null)
            {
                GameObject x = AllOption[i].AddComponent<BoxCollider2D>().gameObject as GameObject;
                x.GetComponent<BoxCollider2D>().size = new Vector2(94, 46);
                x.GetComponent<MultipleDrag>().B_corret = false;
                x.GetComponent<MultipleDrag>().B_matched = false;
            }

            AllOption[i].SetActive(true);
        }
        dash_count_S1 = 0;
        dash_count_S3 = 0;

        BackTo_QuesAns[0].SetActive(true);
        BackTo_QuesAns[1].SetActive(false);

        



    }
}