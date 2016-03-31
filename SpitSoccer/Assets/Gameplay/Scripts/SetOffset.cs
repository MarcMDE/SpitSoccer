using UnityEngine;
using System.Collections;

public class SetOffset : MonoBehaviour 
{
    [SerializeField] float amount;
    [SerializeField] Vector3 direction;

	void Start () 
    {
        transform.position += direction * amount;
	}
}
