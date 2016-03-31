using UnityEngine;
using System.Collections;

public class KickZoneLogic : MonoBehaviour 
{
    [SerializeField] BallBehaviour ball;
    [SerializeField] KickerLogic kicker;
    SpriteRenderer sprite;

    public KickerLogic Kicker
    {
        get
        {
            Debug.Log("here");
            return kicker;
        }
    }

	void Start () 
    {
        if (ball == null) ball = GameObject.Find("Ball").GetComponent<BallBehaviour>();
        if (kicker == null) kicker = GetComponentInParent<KickerLogic>();

        sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update () 
    {
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Ball")
        {
            //Debug.Log(character.KickForce);
            ball.AddKickForce(kicker.KickDirecion, kicker.KickBoost);
            //sprite.color = Color.red;
        }
    }
}
