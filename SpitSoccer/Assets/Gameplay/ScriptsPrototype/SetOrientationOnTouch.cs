using UnityEngine;
using System.Collections;

public class SetOrientationOnTouch : MonoBehaviour 
{
    enum OrientationStates {WAITING, SETTING}
    OrientationStates orientationState;

    [SerializeField] string colliderTag;
    [SerializeField] Camera currentCamera;
    [SerializeField] bool orientateParent;
    [SerializeField] LayerMask touchLayer;

    Collider2D other;
    Vector3 worldTouchPosition;
    Vector3 direction;

	void Start () 
    {
        if (currentCamera == null) currentCamera = Camera.main;
        if (colliderTag == null) colliderTag = "Untagged";
        other = null;
        worldTouchPosition = Vector3.zero;
        direction = Vector3.zero;
	}
	
	void Update () 
    {
        if (Input.touchCount > 0) // If any touch
        {
            worldTouchPosition = currentCamera.ScreenToWorldPoint(Input.GetTouch(0).position);

            switch (orientationState)
            {
                case OrientationStates.WAITING:
                {
                    other = Physics2D.OverlapPoint(new Vector2(worldTouchPosition.x, worldTouchPosition.y), touchLayer.value);

                    if (other != null)
                    {
                        Debug.Log(other.tag);
                        if (other.tag == colliderTag)
                        {
                            orientationState = OrientationStates.SETTING;
                        }
                    }
                } break;

                case OrientationStates.SETTING:
                {
                        direction = GetDirection(other.transform.position, worldTouchPosition);
                        other.transform.parent.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
                        //else other.transform.forward = GetDirection(other.transform.position, worldTouchPosition);
                } break;

                default: break;
            }
        }
        else if (orientationState == OrientationStates.SETTING)
        {
            orientationState = OrientationStates.WAITING;
            other.gameObject.SetActive(false);
        }
	}

    Vector3 GetDirection (Vector3 a, Vector3 b)
    {
        Vector3 heading = b - a;
        //float distance = heading.normalized.magnitude;
        return heading.normalized;
    }
}
