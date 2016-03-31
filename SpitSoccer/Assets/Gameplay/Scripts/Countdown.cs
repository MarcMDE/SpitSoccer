using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour 
{
    [SerializeField] float countDuration;
    [SerializeField] int countLenght;
    [SerializeField] string lastMessage;
    [SerializeField] Text text;

    float timeCounter;
    bool isCountdownFinished;

	void Start () 
    {
        if (lastMessage == null) lastMessage = "GO!";
        if (countDuration == 0) countDuration = 0.5f;
        if (text == null) GetComponent<Text>();

        isCountdownFinished = false;
        text.text = countLenght.ToString();
	}
	
	void Update () 
    {
        if (timeCounter >= countDuration)
        {
            countLenght--;
            if (countLenght < 1)
            {
                text.text = lastMessage;

                if (countLenght < 0) isCountdownFinished = true;
            }
            else text.text = countLenght.ToString();
            timeCounter = 0;
        }
        else timeCounter+=Time.deltaTime;
	}

    public bool IsFinished ()
    {
        return isCountdownFinished;
    }
}
