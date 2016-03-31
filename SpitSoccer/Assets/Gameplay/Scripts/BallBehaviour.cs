using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour 
{
    float speed;
    Vector2 direction;
    Vector3 lastPosition;

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    Rigidbody2D rBody;

	void Start () 
    {
        rBody = GetComponent<Rigidbody2D>();

        lastPosition = transform.position;
	}

    void Update ()
    {
        direction = UtilsV2.GetDirectionV2(lastPosition, transform.position);
    }

    void FixedUpdate ()
    {
        lastPosition = transform.position;
    }

    void SetVelocity (Vector2 direction, float speed)
    {
        rBody.velocity = direction * speed;
    }
    void SetVelocity ()
    {
        rBody.velocity = direction * speed;
    }

    public void AddKickForce (Vector2 direction, float boost)
    {
        // Set boost bonus depending on orientation (DotProduct)
        speed += Vector2.Dot(this.direction, direction) * boost;
        Debug.Log(speed);

        // Set new direction between ball and kick. 

        this.direction = UtilsV2.NormalizeV2(this.direction + direction);

        /*
        if (this.direction.x > 1) this.direction.x = 1;
        else if (this.direction.x < -1) this.direction.x = -1;

        if (this.direction.y > 1) this.direction.y = 1;
        else if (this.direction.y < -1) this.direction.y = -1;
        */

        //Debug.Log(this.direction);

        SetVelocity(this.direction, speed);
    }

    public void Stop ()
    {
        direction = Vector2.zero;
        SetVelocity(direction, 0);
    }

    public void DirectionInvert (bool xAxis)
    {
        if (xAxis) direction.x *= -1;
        else direction.y *= -1;
        SetVelocity(direction, speed);
    }

    public void AddSpeedBoost (float boost)
    {
        speed += boost;
        SetVelocity();
    }

    public void Kick (Vector2 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;

        SetVelocity();
    }
}
