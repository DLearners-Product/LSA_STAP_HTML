using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
using TMPro;
using UnityEngine.UI;
public class BlendedOperations : MonoBehaviour
{
    public Bridge bridge;
    public static BlendedOperations instance;
    
    private void Start()
    {
        if(this == null){
            instance = this;
        }
    }

    public void SetBlendedData(string blendedData){
        // Debug.Log("From Unity ");
        // Debug.Log(blendedData);
        // Debug.Log("------------------------------------------------------------");
        // JSONParser parser = new JSONParser();
        blendedData = blendedData.Replace("\"[", "[").Replace("]\"", "]").Replace("\\", "");
        JSONNode blendedParsedData = JSON.Parse(blendedData);

        // Debug.Log(blendedParsedData.GetType());
        // Debug.Log(blendedParsedData[0]);
        // Debug.Log(blendedParsedData.Count);

        for(int i=0; i<blendedParsedData.Count; i++){
            List<TextComponentData> slideTextComponents = MainBlendedData.instance.slideDatas[Int32.Parse(blendedParsedData[i]["slide_flow_id"]) - 1].textComponents;
            
            // Debug.Log(MainBlendedData.instance.slideDatas[Int32.Parse(blendedParsedData[i]["slide_flow_id"])].slideName, MainBlendedData.instance.slideDatas[Int32.Parse(blendedParsedData[i]["slide_flow_id"])].slideObject);

            foreach(var slideTextComponent in slideTextComponents){
                // Debug.Log(slideTextComponent.componentID + " ----- " + blendedParsedData[i]["component_id"]);
                if(slideTextComponent.componentID == blendedParsedData[i]["component_id"]){
                    // Debug.Log("Came In chnage value to : "+blendedParsedData[i]["paragraph"]);
                    if(slideTextComponent.component.GetComponent<Text>() != null){
                        slideTextComponent.component.GetComponent<Text>().text = blendedParsedData[i]["paragraph"];
                    }else {
                        slideTextComponent.component.GetComponent<TMP_Text>().text = blendedParsedData[i]["paragraph"];
                    }
                }
            }
        }

        Main_Blended.OBJ_main_blended.THI_cloneLevels();
    }

    public void GetBlendedData(){
        Debug.Log("Came to GetBlendedData");
        string blendedData = "[";
        List<SlideDataContainer> slideDataContainer = MainBlendedData.instance.slideDatas;

        for(int i = 0; i < slideDataContainer.Count; i++){
            SlideData slideData = new SlideData();
            slideData.slideName = slideDataContainer[i].slideName;
            List<string> slideTexts = new List<string>();
            for(int j=0; j<slideDataContainer[i].textComponents.Count; j++){
                slideTexts.Add(JsonUtility.ToJson(
                    new TextComponent(
                        slideDataContainer[i].textComponents[j].componentID, 
                        (slideDataContainer[i].textComponents[j].component.GetComponent<Text>() != null) ? slideDataContainer[i].textComponents[j].component.GetComponent<Text>().text : slideDataContainer[i].textComponents[j].component.GetComponent<TMP_Text>().text
                    )
                ));
            }
            slideData.slideTexts = "["+string.Join(", ", slideTexts)+"]";

            // for JSON formating
            if( i > 0){
                blendedData += ", ";
            }
            blendedData += JsonUtility.ToJson(slideData);
        }
        blendedData += "]";

        Application.ExternalCall("send_blended_data", blendedData);
        // Debug.Log("Blended Data : "+blendedData);
    }

    Transform FindGameObject(GameObject rootObject, string gameObjectName){
        if(gameObjectName == rootObject.name){
            return rootObject.transform;
        }
        for(int i=0; i<rootObject.transform.childCount; i++){
            Transform findObject = FindGameObject(rootObject.transform.GetChild(i).gameObject, gameObjectName);
            if(findObject != null) return findObject;
        }
        return null;
    }
#region EXTERNAL_JS_INVOKE_FUNCTIONS

    // Called from external JS
    public void GetActivityScoreData(){
        Debug.Log($"Came to GetActivityScoreData");
        string scoreData =  ScoreManager.instance.GetActivityData();
        bridge.SendActivityScoreData(scoreData);
        ScoreManager.instance.ResetActivityData();
    }

    public void CheckFunc(){
        Debug.Log($"In BlendedOperations CheckFunc");
    }
#endregion

#region ADD_SYLLABIFYING_SETUP

    public void ChangeSyllabifyTCName(){
        // Debug.Log($"came to ChangeSyllabifyTCName");
        List<TextComponentData> textComponents = MainBlendedData.instance.slideDatas[Main_Blended.OBJ_main_blended.levelno].textComponents;

        for(int i=0; i<textComponents.Count; i++){
            if(!textComponents[i].component.name.Contains(textComponents[i].componentID))
                textComponents[i].component.name = textComponents[i].componentID + textComponents[i].component.name;
        }
    }

    public void AddButtonToSyllabifyingTC(){
        // Debug.Log($"came to AddButtonToSyllabifyingTC");

        if(!Main_Blended.OBJ_main_blended.HAS_SYLLABLE[Main_Blended.OBJ_main_blended.levelno]) return;

        List<TextComponentData> textComponentData = MainBlendedData.instance.slideDatas[Main_Blended.OBJ_main_blended.levelno].textComponents;
        Transform textField;
        for(int i=0; i<textComponentData.Count; i++){
            Debug.Log(Main_Blended.OBJ_main_blended.G_currenlevel.name);
            Debug.Log($"{MainBlendedData.instance.slideDatas[Main_Blended.OBJ_main_blended.levelno].slideName}");
            Debug.Log($"{i} : {textComponentData[i].component.name}");

            // textField = G_currenlevel.transform.Find(textComponentData[i].component.name);
            textField = FindGameObject(Main_Blended.OBJ_main_blended.G_currenlevel, textComponentData[i].component.name);
            if(textField != null){
                // Debug.Log($"{textField} : {textField == null}");

                string textCompValue = (textField.GetComponent<Text>()) ? textField.GetComponent<Text>().text : textField.GetComponent<TMP_Text>().text;

                if(textField.gameObject.GetComponent<Button>() == null){
                    // Debug.Log("In if condition");
                    textField.gameObject.AddComponent<Button>().onClick.AddListener(() => { SendDataToSylabify(textCompValue); });
                }else{
                    Debug.Log("In else condition");
                    textField.gameObject.GetComponent<Button>().onClick.AddListener(() => { SendDataToSylabify(textCompValue); });
                }
            }
        }
    }

    void SendDataToSylabify(string dataToSyllabify){
        Debug.Log("SendDataToSylabify ...");
        Debug.Log(dataToSyllabify);
        bridge.SyllabyfyText(dataToSyllabify);
    }

#endregion

}
