using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenBounds : MonoBehaviour 
{
    [SerializeField] Camera currentCamera;
    [SerializeField] float colliderWidth;
    [SerializeField] PhysicsMaterial2D physicsMaterial;

	void Start () 
    {
        if (currentCamera == null) currentCamera = Camera.main;

        Dictionary<string, GameObject> colliders = new Dictionary<string, GameObject>();

        colliders.Add("Top", new GameObject());
        colliders.Add("Bot", new GameObject());
        colliders.Add("Right", new GameObject());
        colliders.Add("Left", new GameObject());

        /*
        Vector3 worldScreenMin = currentCamera.ScreenToWorldPoint(Vector2.zero) ;
        Vector3 worldScreenMax = currentCamera.ScreenToWorldPoint(new Vector2(currentCamera.pixelWidth, currentCamera.pixelHeight));
        */

        Vector2 worldScreenSize = currentCamera.ScreenToWorldPoint(new Vector2(currentCamera.pixelWidth, currentCamera.pixelHeight)) - currentCamera.ScreenToWorldPoint(Vector2.zero);

        foreach (KeyValuePair<string, GameObject> obj in colliders)
        {
            obj.Value.AddComponent<BoxCollider2D>(); //Add collider.
            if (physicsMaterial != null) obj.Value.GetComponent<BoxCollider2D>().sharedMaterial = physicsMaterial;
            obj.Value.name = obj.Key + "BoundCollider"; //Set the object's name.
            obj.Value.transform.parent = transform; //Make the object a child of whatever object this script is on (preferably the camera)

            if (obj.Key == "Left" || obj.Key == "Right") //Scale the object to the width and height of the screen.
                obj.Value.transform.localScale = new Vector3(colliderWidth, worldScreenSize.y + colliderWidth*2, 1);
            else
                obj.Value.transform.localScale = new Vector3(worldScreenSize.x + colliderWidth*2, colliderWidth, colliderWidth);
        }

        colliders["Top"].transform.position = new Vector3(currentCamera.transform.position.x, (currentCamera.transform.position.y + worldScreenSize.y * 0.5f) + colliderWidth * 0.5f, 0);
        colliders["Bot"].transform.position = new Vector3(currentCamera.transform.position.x, (currentCamera.transform.position.y - worldScreenSize.y * 0.5f) - colliderWidth * 0.5f, 0);
        colliders["Right"].transform.position = new Vector3((currentCamera.transform.position.x + worldScreenSize.x * 0.5f) + colliderWidth * 0.5f , currentCamera.transform.position.y, 0);
        colliders["Left"].transform.position = new Vector3((currentCamera.transform.position.x - worldScreenSize.x * 0.5f) - colliderWidth * 0.5f, currentCamera.transform.position.y, 0);
    }
}
