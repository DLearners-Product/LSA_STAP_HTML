using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    string activityData;
    public static ScoreManager instance;
    [SerializeField] BlendedSlideActivityData[] lessonGameActivityDatas;
    // [SerializeField] GameActivityData[] GAA_activityData;

    private void Awake()
    {
        instance = this;
    }

    private void Start() {
        InitializeLessonActivityData(Main_Blended.OBJ_main_blended.GA_levelsIG.Length);
    }

    public void InitializeLessonActivityData(int arrLength){
        lessonGameActivityDatas = new BlendedSlideActivityData[arrLength];
        for(int i=0; i<lessonGameActivityDatas.Length; i++){
            if(lessonGameActivityDatas[i] == null){
                lessonGameActivityDatas[i] = new BlendedSlideActivityData();
            }
        }
    }

    public void InstantiateScore(int arrSize){
        Debug.Log($"came to InstantiateScore "+arrSize);
        Debug.Log($"Level No : "+Main_Blended.OBJ_main_blended.levelno);
        Debug.Log(lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities);

        if(lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities == null || lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities.Length <= 0){
            Debug.Log($"Slide activity initialized");
            lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities = new SlideActivityData[arrSize];
        }else{
            Debug.Log($"Slide activity not initialized");
        }
    }

    public void THI_InitialiseGameActivity(int QIndex){
        if (lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[QIndex] == null){
            lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[QIndex] = new SlideActivityData(QIndex);
        }
    }

    public string GetActivityData(int levelno = -1){
        if(levelno == -1)
            levelno = Main_Blended.OBJ_main_blended.levelno;

        if(lessonGameActivityDatas[levelno].slideActivities != null && lessonGameActivityDatas[levelno].slideActivities.Length > 0){
            return null;
        }

        activityData = "[";

        for(int i=0; i < lessonGameActivityDatas[levelno].slideActivities.Length; i++){
            activityData += lessonGameActivityDatas[levelno].slideActivities[i].getParsedJsonData();
            if((i+1) < lessonGameActivityDatas[levelno].slideActivities.Length){
                activityData += ",";
            }
        }

        activityData = "]";
        return activityData;
    }

    public void ResetActivityData(int QIndex){
        
    }

    // public string GetAllActivityData(){
    // }

    public void RightAnswer(int questionIndex, int scorevalue = 1){
        THI_InitialiseGameActivity(questionIndex);
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[questionIndex].tries++;
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[questionIndex].score += scorevalue;
    }

    public void WrongAnswer(int questionIndex, int scorevalue = 1){
        THI_InitialiseGameActivity(questionIndex);
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[questionIndex].tries++;
        lessonGameActivityDatas[Main_Blended.OBJ_main_blended.levelno].slideActivities[questionIndex].failures += scorevalue;
    }
}
