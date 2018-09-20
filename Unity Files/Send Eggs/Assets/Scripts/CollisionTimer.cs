using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTimer : MonoBehaviour {

    private Rigidbody2D rigid;
    public ParticleSystem yolk;

	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision registered");
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(yolk, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
