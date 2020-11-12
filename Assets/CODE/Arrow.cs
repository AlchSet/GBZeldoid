using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {


    Collider2D col;

	// Use this for initialization
	void Start () {
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT");
        StartCoroutine(ArrowHit());
    }

    IEnumerator ArrowHit()
    {
        col.enabled = false;
        transform.localScale = new Vector3(1, -1, 1);
        transform.root.GetComponent<Rigidbody2D>().velocity = -transform.root.right*2;
        transform.root.GetComponent<Rigidbody2D>().AddTorque(199);

        yield return new WaitForSeconds(0.08f);
        Destroy(transform.root.gameObject);
    }


}
