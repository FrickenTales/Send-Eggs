using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour {

    private Rigidbody2D rb2d;
    private GameObject body;
    private float bodyRotation;
    public float moveSpeed;
    public float jumpPower;
    public Collider col;
    public Ray ray;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        body = transform.GetChild(0).gameObject;
        col = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * 0.1f;
        bodyRotation = Input.GetAxis("Horizontal") * 20;
        bodyRotation = Mathf.Clamp(bodyRotation, -20, 20);
        body.transform.rotation = Quaternion.Euler(0, 0, bodyRotation);

        rb2d.MovePosition(new Vector2(transform.position.x + x, transform.position.y));

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);

            rb2d.AddForce(new Vector2(0, jumpPower));
        }

    }

    protected Vector3 GetNormalOfHit(Collider collider)
    {//get the angle of the collision
        Vector3 rayDestination = collider.bounds.center;//destination of ray (center of collider)	
        Vector3 rayOrigin = col.ClosestPointOnBounds(rayDestination);//origin of ray (point on the character)
        Vector3 rayDiff = rayDestination - rayOrigin;//vector describing the difference between the 2 previous vectors
        rayOrigin -= rayDiff.normalized * 5;//inset the origin according to the angle between origin and destination so if there is overlap, the ray will still hit. 
        rayDiff = rayDestination - rayOrigin;//rebuild the difference with new origin
        ray.origin = rayOrigin;//set the origin of the ray (I‘m reusing rays this is why there is no instantiation.)
        ray.direction = rayDiff.normalized;//set the direction of the ray
        RaycastHit hit;
        if (rayDiff.magnitude > 0)
        {//make sure there are no errors due to exceptionnal occurences.
            collider.Raycast(ray, out hit, rayDiff.magnitude + 2f);//cast the ray on the collider (only the collider)
            return hit.normal;//return the normal, it’ll determine we hit the top/sides or bottom of the object.
        }
        return new Vector3();
    }
}
