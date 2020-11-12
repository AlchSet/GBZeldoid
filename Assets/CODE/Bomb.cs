using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    Animator anim;

    public float Duration=3;

    float elapsed;

    bool exploded;


    public float radius = 2;

    ParticleSystem particles;


    public LayerMask mask;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        particles = transform.Find("sparks").GetComponent<ParticleSystem>();
        particles.Stop();
	}
	
	// Update is called once per frame
	void Update () {



        if(!exploded)
        {

            elapsed += Time.deltaTime;


            anim.SetFloat("tick", Mathf.Lerp(1, 5, elapsed / Duration));

            if (elapsed >= Duration)
            {
                //particles.Stop();
                //particles.Emit(30);
                particles.Play();
                anim.Play("Explode");
                exploded = true;
                
                
            }

        }
        
	}


    public void ExplosionDamage()
    {

        Collider2D[] victims = Physics2D.OverlapCircleAll(transform.position, radius, mask);


        foreach(Collider2D v in victims)
        {
            v.GetComponent<Damageable>().DealDamage(1);
        }

    }


    public void OnDrawGizmos()
    {
        Color c = Color.red;

        c.a = 0.6f;

        Gizmos.color = c;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
