using UnityEngine;
using System.Collections;

public class OnEnemyCollision : MonoBehaviour 
{
    [SerializeField] string collisionTag;
    [SerializeField] GameMaster gameMaster;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == collisionTag)
        {
            gameMaster.GameEnd(false);
        }
    }
}
