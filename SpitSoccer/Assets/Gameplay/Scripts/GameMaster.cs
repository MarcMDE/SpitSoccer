using UnityEngine;
using System.Collections;

public enum GameStates { COUNTDOWN, ORIENTATION, EXECUTION, END};

public class GameMaster : MonoBehaviour 
{
    [SerializeField] Countdown initCountdown;
    [SerializeField] BallBehaviour ball;
    [SerializeField] SetKickersOrientation kickersOrientation;
    [SerializeField] FirstKickerTouch firstKickerTouch;
    [SerializeField] GameObject firstKickerArrow;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    KickerLogic [] kickers;
    bool kickersOrientated;

    GameStates gameState;

	void Start () 
    {
        if (ball == null) ball = GameObject.Find("Ball").GetComponent<BallBehaviour>();
        if (kickersOrientation == null) kickersOrientation = GameObject.Find("Player").GetComponent<SetKickersOrientation>();
 
        kickers = GetComponentsInChildren<KickerLogic>();

        firstKickerArrow.SetActive(false);
        for (int i = 0; i < kickers.Length; i++) kickers[i].enabled = false;
        kickersOrientation.enabled = false;
        kickersOrientated = false;
        firstKickerTouch.enabled = false;

        gameState = GameStates.COUNTDOWN;
	}
	
	void Update () 
    {
	    switch(gameState)
        {
            case GameStates.COUNTDOWN:
            {
                if (initCountdown.IsFinished())
                {
                    // Init orientation
                    initCountdown.gameObject.SetActive(false);
                    GoToNextGameState();

                    // Enable characters and orientation logic
                    for (int i = 0; i < kickers.Length; i++) kickers[i].enabled = true;
                    kickersOrientation.enabled = true;
                        firstKickerTouch.enabled = true;
                    firstKickerArrow.SetActive(true);
                }
            } break;
            case GameStates.ORIENTATION:
            {
                // Check if all characters have been oriented
                kickersOrientated = true;
                for (int i = 0; i < kickers.Length; i++)
                {
                    if (!kickers[i].IsOrientated())
                    {
                        kickersOrientated = false;
                        i = kickers.Length;   
                    }
                }
            } break;
            case GameStates.EXECUTION:
            {
                //if (ball.Speed <= 0) GameEnd(false);
            } break;
            case GameStates.END:
            {

            } break;
            default: break;
        }
	}

    public void GoToNextGameState()
    {
        gameState++;
    }

    public void GameEnd (bool win)
    {
        if (gameState != GameStates.END)
        {
            if (win)
            {
                winScreen.SetActive(true);
            }
            else
            {
                loseScreen.SetActive(true);
            }
            ball.Stop();
            gameState = GameStates.END;
        }
    }

    public void StartExecutionMode ()
    {
        gameState = GameStates.EXECUTION;

        //ball.gameObject.SetActive(true);
        kickersOrientation.enabled = false;
        firstKickerTouch.enabled = false;
    }
}
