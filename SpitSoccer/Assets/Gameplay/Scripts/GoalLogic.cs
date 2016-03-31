using UnityEngine;
using System.Collections;

public class GoalLogic : MonoBehaviour 
{
    [SerializeField] string colliderTag;
    [SerializeField] GameMaster gameMaster;

	void Start () 
    {
        if (colliderTag == null) colliderTag = "Ball";
        if (gameMaster == null) gameMaster = GameObject.Find("MainObject").GetComponent<GameMaster>();
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == colliderTag)
        {
            gameMaster.GameEnd(true);
        }
    }
}
