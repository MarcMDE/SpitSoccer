using UnityEngine;
using System.Collections;

public class OnWorldTouch : MonoBehaviour 
{
    [SerializeField] Camera currentCamera;
    Vector3 onWorldTouchPosition;
    bool anyTouch;

    public bool AnyTouch
    {
        get
        {
            //return anyTouch;
            return Input.GetMouseButton(0);
        }
    }

	void Start () 
    {
        if (currentCamera == null) currentCamera = Camera.main;
        onWorldTouchPosition = Vector3.zero;
        anyTouch = false;
	}
	
	void Update () 
    {
        /*
        anyTouch = false;
	    if (Input.touchCount > 0)
        {
            anyTouch = true;
            onWorldTouchPosition = currentCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        */
        onWorldTouchPosition = currentCamera.ScreenToWorldPoint(Input.mousePosition);
	}

    public Vector3 GetTouchPosition ()
    {
        return onWorldTouchPosition;
    }
}
