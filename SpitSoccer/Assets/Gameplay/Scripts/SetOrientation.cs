using UnityEngine;
using System.Collections;

public class SetOrientation : MonoBehaviour 
{
    public void Orientate(Vector3 direction)
    {
        //Debug.Log(direction);
        this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
    }
}
