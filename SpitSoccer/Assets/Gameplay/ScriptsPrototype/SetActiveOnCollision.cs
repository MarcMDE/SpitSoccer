using UnityEngine;
using System.Collections;

public class SetActiveOnCollision : MonoBehaviour 
{
    [SerializeField] string colliderTag;
    GameMaster master;

	void Start () 
    {
        if (colliderTag == null) colliderTag = "Untagged";
        if (master == null) master = GameObject.Find("MainObject").GetComponent<GameMaster>();
	}
	
	void Update () 
    {
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == colliderTag)
        {
            master.GameEnd(true);
            Debug.Log("Ball reached the goal");
        }
    }
}
