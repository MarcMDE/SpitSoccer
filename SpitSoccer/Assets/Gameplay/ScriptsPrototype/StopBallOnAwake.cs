using UnityEngine;
using System.Collections;

public class StopBallOnAwake : MonoBehaviour 
{

    [SerializeField] BallBehaviour ball;

    void Awake ()
    {
        if (ball == null) ball = GameObject.Find("Ball").GetComponent<BallBehaviour>();
    }

    void OnEnable ()
    {
        ball.Stop();
    }
}
