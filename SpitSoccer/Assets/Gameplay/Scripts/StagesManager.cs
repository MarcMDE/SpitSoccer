using UnityEngine;
using System.Collections;

public class StagesManager : MonoBehaviour 
{
    enum Stages { FIRST, SECOND, FINAL};
    Stages currentStage;

    [SerializeField] Camera currentCamera;

    [SerializeField] GameObject [] stages = new GameObject[System.Enum.GetValues(typeof(Stages)).Length];
    [SerializeField] float transitionDuration;

    [SerializeField] Transform ball;
    [SerializeField] GameObject [] stagesStaticObjects = new GameObject[System.Enum.GetValues(typeof(Stages)).Length - 1];

    [SerializeField] float staticObjectsHeight;

    float timeCounter;
    bool isTransitioning;
    float screenHeight;

    void Start () 
    {
        timeCounter = 0;
        currentStage = Stages.FIRST;
        isTransitioning = false;

        screenHeight = currentCamera.ScreenToWorldPoint(Vector3.zero).y - currentCamera.ScreenToWorldPoint(Vector3.up * currentCamera.pixelHeight).y;

        for (int i=0; i< System.Enum.GetValues(typeof(Stages)).Length; i++)
        {
            if (i != (int)currentStage) stages[i].SetActive(false);
        }
	}
	
	void Update () 
    {
        if (Input.GetKey(KeyCode.Space)) TransitionToNextStage();

	    if (isTransitioning)
        {
            if (timeCounter < transitionDuration)
            {
                stages[(int)currentStage].transform.position = Vector3.up * (float)Easing.CubicEaseInOut(timeCounter, 0, screenHeight, transitionDuration);

                if (stagesStaticObjects[(int)currentStage].transform.position.y < staticObjectsHeight)
                    stagesStaticObjects[(int)currentStage].transform.position = new Vector3(stagesStaticObjects[(int)currentStage].transform.position.x, staticObjectsHeight, stagesStaticObjects[(int)currentStage].transform.position.z);

                for (int i=(int)currentStage+1; i<System.Enum.GetValues(typeof(Stages)).Length; i++)
                {
                    stages[i].transform.position = stages[i - 1].transform.position - screenHeight * Vector3.up;
                }
                

                timeCounter += Time.deltaTime;
            }
            else
            {
                stages[(int)currentStage].transform.position = Vector3.up * (float)Easing.CubicEaseInOut(transitionDuration, 0, screenHeight, transitionDuration);

                
                for (int i = (int)currentStage + 1; i < System.Enum.GetValues(typeof(Stages)).Length; i++)
                {
                    stages[i].transform.position = stages[i - 1].transform.position - screenHeight * Vector3.up;
                }

                stagesStaticObjects[(int)currentStage].transform.SetParent(stages[(int)currentStage + 1].transform);

                stages[(int)currentStage].SetActive(false);
                
                currentStage++;
                isTransitioning = false;
            }
        }
	}

    public void TransitionToNextStage ()
    {
        if ((int)currentStage < System.Enum.GetValues(typeof(Stages)).Length -1)
        {
            timeCounter = 0;
            isTransitioning = true;
            stages[(int)currentStage + 1].SetActive(true);
        }
    }

    public int GetCurrentStage ()
    {
        return (int)currentStage;
    }

}
