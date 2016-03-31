using UnityEngine;
using System.Collections;

public enum CharacterStates {IDLE, READY, KICKING, END};

public class KickerLogic : MonoBehaviour
{
    [SerializeField] float kickBoost;
    [SerializeField] GameObject touchCollider;
    [SerializeField] GameObject kickZone;

    Vector2 kickDirection;
    bool isOrientated;

    public Vector2 KickDirecion
    {
        get
        {
            return kickDirection;
        }
    }

    public float KickBoost
    {
        get
        {
            return kickBoost;
        }
    }

    CharacterStates state;

	void Start () 
    {
        state = CharacterStates.IDLE;
        isOrientated = false;

        kickDirection = Vector2.up;
        kickZone.SetActive(false);
	}

    public void SetKick ()
    {
        isOrientated = true;
        state = CharacterStates.READY;
        touchCollider.SetActive(false);
    }
    
    public void Orientate (Vector3 direction)
    {
        if (!kickZone.activeInHierarchy) kickZone.SetActive(true);
        kickZone.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        kickDirection = direction;
    }

    public bool IsOrientated ()
    {
        return isOrientated;
    }
}
