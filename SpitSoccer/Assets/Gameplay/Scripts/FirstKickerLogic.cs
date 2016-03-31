using UnityEngine;
using System.Collections;

public class FirstKickerLogic : MonoBehaviour 
{
    [SerializeField] GameMaster gameMaster;

    [SerializeField] BallBehaviour ball;
    [SerializeField] RotateToAngle arrow;

    [SerializeField] Vector2 ballOffset;
    [SerializeField] float ballSpeed;

	void Start () 
    {
        ball.transform.position = transform.position + new Vector3(ballOffset.x, ballOffset.y, 0);
        //ball.enabled = false;
	}
	
    public void KickBall ()
    {
        ball.enabled = true;
        ball.Kick(UtilsV2.DirectionFromAngle(arrow.Angle + 90), ballSpeed);
        gameMaster.StartExecutionMode();
        arrow.gameObject.SetActive(false);
    }
}
