using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour {


    public Transform sprite;
    public Collider2D Col;

    bool hasFallen;
    
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Holes"))
        {
            Debug.Log("OBJECT FALL");
            if (!hasFallen)
                StartCoroutine(Fall(collision.transform.position));
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Sink();
        }

    }

    public void Sink()
    {
        hasFallen = true;
        Col.enabled = false;
        sprite.gameObject.SetActive(false);

    }

    IEnumerator Fall(Vector2 pos)
    {
        hasFallen = true;
        Col.enabled = false;
        StartCoroutine(MovetoHole(pos));
        while(true)
        {
            sprite.localScale = Vector3.MoveTowards(sprite.localScale, Vector3.zero, Time.deltaTime*4);
            sprite.Rotate(Vector3.forward * Time.deltaTime * 100);

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }


    IEnumerator MovetoHole(Vector2 p)
    {
        while(true)
        {
            transform.parent.position = Vector2.MoveTowards(transform.position, p, Time.deltaTime*5);
            if(Vector2.Distance(transform.position,p)<=0)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
