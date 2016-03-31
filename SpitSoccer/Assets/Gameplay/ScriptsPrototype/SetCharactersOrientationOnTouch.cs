using UnityEngine;
using System.Collections;

public class SetCharactersOrientationOnTouch : MonoBehaviour
{
    enum OrientationStates { WAITING, SETTING }
    OrientationStates orientationState;

    [SerializeField]
    string colliderTag;
    [SerializeField]
    Camera currentCamera;
    [SerializeField]
    LayerMask touchLayer;

    KickerLogic currentKicker;
    Collider2D other;
    Vector3 worldTouchPosition;
    Vector3 direction;

    void Start()
    {
        if (currentCamera == null) currentCamera = Camera.main;
        if (colliderTag == null) colliderTag = "Untagged";

        other = null;
        worldTouchPosition = Vector3.zero;
        direction = Vector3.zero;
    }

    void Update()
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
                                currentKicker = other.transform.parent.GetComponent<KickerLogic>();
                            }
                        }
                    }
                    break;

                case OrientationStates.SETTING:
                    {
                        direction = GetDirectionV2(other.transform.position, worldTouchPosition);
                        currentKicker.Orientate(direction);
                    }
                    break;

                default: break;
            }
        }
        else if (orientationState == OrientationStates.SETTING)
        {
            currentKicker.SetKick();
            orientationState = OrientationStates.WAITING;
        }
    }

    Vector3 GetDirectionV2(Vector3 a, Vector3 b)
    {
        Vector3 heading = b - a;
        //float distance = heading.normalized.magnitude;
        return NormalizeV2(heading);
    }

    Vector3 NormalizeV2(Vector3 v)
    {
        float lenght = Mathf.Sqrt(v.x * v.x + v.y * v.y);
        return v/lenght;
    }
}
