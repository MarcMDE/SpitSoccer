using UnityEngine;
using System.Collections;

public class BounceOnScreenBounds : MonoBehaviour 
{
    [SerializeField] BallBehaviour ballBehaviour;
    [SerializeField] Transform ballTransform;
    [SerializeField] Camera currentCamera;
    [SerializeField] float speedBoost;

    Vector2 worldMin;
    Vector2 worldMax;
    bool isDirectionSet;
    
	void Start () 
    {
        if (ballBehaviour == null) ballBehaviour = GameObject.Find("Ball").GetComponent<BallBehaviour>();
        if (ballTransform == null) ballTransform = GameObject.Find("Ball").GetComponent<Transform>();
        if (currentCamera == null) currentCamera = Camera.main;

        worldMin = currentCamera.ScreenToWorldPoint(Vector3.zero);
        worldMax = currentCamera.ScreenToWorldPoint(new Vector3(currentCamera.pixelWidth, currentCamera.pixelHeight, 0));

        // Used for skipping 1 frame after directions setting in order to avoid the double direction setting making the ball go out the screen
        isDirectionSet = false;
	}
	
	void Update ()
    {
        if (!isDirectionSet)
        {
            if (ballTransform.position.x < worldMin.x || ballTransform.position.x > worldMax.x)
            {
                ballBehaviour.DirectionInvert(true);
                ballBehaviour.AddSpeedBoost(speedBoost);
                isDirectionSet = true;
            }
            if (ballTransform.position.y < worldMin.y || ballTransform.position.y > worldMax.y)
            {
                ballBehaviour.DirectionInvert(false);
                ballBehaviour.AddSpeedBoost(speedBoost);
                isDirectionSet = true;
            }
        }
        else isDirectionSet = false;
	}
}
