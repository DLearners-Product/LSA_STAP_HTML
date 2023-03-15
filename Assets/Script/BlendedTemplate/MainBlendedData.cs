using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class MainBlendedData : MonoBehaviour
{
    public List<SlideDataContainer> slideDatas;
    List<int> slideDataCounts;
    public static MainBlendedData instance;
    List<GameObject> textObjects;
    List<SlideDataContainer> oldSlideData;
    int currentSlideIndex = 0;

    private void Awake() {
        textObjects = new List<GameObject>();
        oldSlideData = new List<SlideDataContainer>();

        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        Debug.Log($"start method called");
        slideDataCounts = new List<int>();
        if(slideDatas != null){
            for(int i=0; i<slideDatas.Count; i++){
                oldSlideData.Add(slideDatas[i]);
            }
        }
    }

    void Update()
    {
        if(Application.isEditor && !Application.isPlaying){
            UpdateInspector();
        }
    }

    public void UpdateInspector(bool buttonClicked=false){
        for(; currentSlideIndex < slideDatas.Count; currentSlideIndex++){
            bool isNewActivity = ((oldSlideData.Count - 1) < currentSlideIndex && slideDatas[currentSlideIndex].slideObject != null);
            bool isOldActivityChanged = ((oldSlideData.Count) > currentSlideIndex && oldSlideData[currentSlideIndex].slideObject != slideDatas[currentSlideIndex].slideObject);

            if(isNewActivity || isOldActivityChanged || buttonClicked){
                if(isNewActivity){
                    oldSlideData.Add(slideDatas[currentSlideIndex]);
                }
                PopulateTextField();
                UpdateOldSlideData();
            }
        }
        buttonClicked = false;
        currentSlideIndex = 0;
    }

    public void PopulateTextField(){
        if(slideDatas[currentSlideIndex].slideObject != null){
            Debug.Log($"Populating text field");

            slideDatas[currentSlideIndex].textComponents = new List<TextComponentData>();
            
            GetAllTextComponent(slideDatas[currentSlideIndex].slideObject);
            
            slideDatas[currentSlideIndex].slideName = slideDatas[currentSlideIndex].slideObject.name;
        }
    }

    void UpdateOldSlideData(){
        oldSlideData[currentSlideIndex].slideName = slideDatas[currentSlideIndex].slideName;
        oldSlideData[currentSlideIndex].slideObject = slideDatas[currentSlideIndex].slideObject;

        oldSlideData[currentSlideIndex].textComponents.Clear();

        for(int i=0; i<slideDatas[currentSlideIndex].textComponents.Count; i++){
            oldSlideData[currentSlideIndex].textComponents.Add(slideDatas[currentSlideIndex].textComponents[i]);
        }
    }

    // public void AssignData(int index){
    //     for(int i=0; i<slideData.Length; i++){
    //         slideData[index].textComponents[0].component.GetComponent<Text>().text="Text changed";
    //     }
    // }

    void GetAllTextComponent(GameObject rootObject){
        if(rootObject.GetComponent<Text>() != null || rootObject.GetComponent<TMP_Text>() != null){
            string textFieldID = "G_"+(slideDatas[currentSlideIndex].textComponents.Count + 1).ToString();
            if( !rootObject.name.Contains(textFieldID) ){
                rootObject.name = textFieldID + rootObject.name;
            }
            slideDatas[currentSlideIndex].textComponents.Add(
                new TextComponentData(textFieldID, rootObject)
            );
        }
        if(rootObject.transform.childCount > 0){
            for(int j=0; j<rootObject.transform.childCount; j++){
                GetAllTextComponent(rootObject.transform.GetChild(j).gameObject);
            }
        }
    }

    void IterPrefabObject(GameObject prefab){
        for(int i=0; i<prefab.transform.childCount; i++){
            Debug.Log(prefab.transform.GetChild(i).name);
        }
    }

    private void OnValidate() {

    }
}
