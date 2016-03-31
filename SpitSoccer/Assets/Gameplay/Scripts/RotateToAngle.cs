using UnityEngine;
using System.Collections;

public class RotateToAngle : MonoBehaviour 
{
    [SerializeField] float sourceAngle;
    [SerializeField] float targetAngle;
    [SerializeField] float rotationSpeed;
    [SerializeField] bool bounce;

    bool goToTarget;
    float angle;

    public float Angle
    {
        get
        {
            return angle;
        }
    }

	void Start () 
    {
        if (sourceAngle > targetAngle && rotationSpeed > 0) rotationSpeed *= -1;
        else if (sourceAngle < targetAngle && rotationSpeed < 0) rotationSpeed *= -1;

        angle = sourceAngle;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        goToTarget = true;
	}
	
	void Update () 
    {
        if (goToTarget) angle += rotationSpeed * Time.deltaTime;
        else angle -= rotationSpeed * Time.deltaTime;

        /*
        if (goToTarget) transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        else transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
        */

        if (sourceAngle > targetAngle)
        {
            if (goToTarget && angle < targetAngle)
            {
                goToTarget = false;
                angle = targetAngle;
            }
            else if (!goToTarget && angle > sourceAngle)
            {
                goToTarget = true;
                angle = sourceAngle;
            }
        }
        else
        {
            if (goToTarget && angle > targetAngle)
            {
                goToTarget = false;
                angle = targetAngle;
            }
            else if (!goToTarget && angle < sourceAngle)
            {
                goToTarget = true;
                angle = sourceAngle;
            }
        }


        transform.rotation = Quaternion.Euler(0, 0, angle);
        

        /*
        if (sourceAngle < targetAngle)
        {
            if (transform.rotation.z > targetAngle)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, targetAngle);
                if (bounce) rotationSpeed *= -1;
            }
            else if (transform.rotation.z < sourceAngle)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, sourceAngle);
                if (bounce) rotationSpeed *= -1;
            }
        }
        else
        {
            if (transform.rotation.z < targetAngle)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, targetAngle);
                if (bounce) rotationSpeed *= -1;
            }
            else if (transform.rotation.z > sourceAngle)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, sourceAngle);
                if (bounce) rotationSpeed *= -1;
            }
        }
        */
    }

    public void IncreaseRotationSpeed (float value)
    {
        if (rotationSpeed > 0) rotationSpeed += value;
        else rotationSpeed -= value;
    }
}
