using UnityEngine;
using System.Collections;

public class FirstKickerTouch : MonoBehaviour 
{
    [SerializeField] OnWorldTouch onWorldTouch;
    [SerializeField] string colliderTag;
    [SerializeField] LayerMask touchLayer;

    [SerializeField] FirstKickerLogic firstKicker;

    Collider2D other;

	void Start () 
    {
        other = null;
	}
	
	void Update () 
    {
        if (onWorldTouch.AnyTouch)
        {
            other = Physics2D.OverlapPoint(new Vector2(onWorldTouch.GetTouchPosition().x, onWorldTouch.GetTouchPosition().y), touchLayer.value);

            if (other != null)
            {
                //Debug.Log(other.tag);
                if (other.tag == colliderTag)
                {
                    firstKicker.KickBall();
                    other.gameObject.SetActive(false);
                }
            }
        }
    }
}
