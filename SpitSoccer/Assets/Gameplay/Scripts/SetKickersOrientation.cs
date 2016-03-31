using UnityEngine;
using System.Collections;

public class SetKickersOrientation : MonoBehaviour
{
    enum OrientationStates { WAITING, SETTING }
    OrientationStates orientationState;

    [SerializeField] OnWorldTouch onWorldTouch;
    [SerializeField] string colliderTag;
    [SerializeField] LayerMask touchLayer;

    KickerLogic currentKicker;
    Collider2D other;
    Vector3 direction;

    void Start()
    {
        if (colliderTag == null) colliderTag = "Untagged";

        other = null;
        direction = Vector3.zero;
    }

    void Update()
    {
        if (onWorldTouch.AnyTouch)
        {
            switch (orientationState)
            {
                case OrientationStates.WAITING:
                {
                    other = Physics2D.OverlapPoint(new Vector2(onWorldTouch.GetTouchPosition().x, onWorldTouch.GetTouchPosition().y), touchLayer.value);
                    Debug.Log(other);
                    if (other != null)
                    {
                        //Debug.Log(other.tag);
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
                    direction = UtilsV2.GetDirectionV2(other.transform.position, onWorldTouch.GetTouchPosition());
                    Debug.DrawLine(other.transform.position, onWorldTouch.GetTouchPosition());
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
}