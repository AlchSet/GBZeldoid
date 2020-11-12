using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{


    public int life = 1;

    public UnityEvent OnDeath;
    public UnityEvent OnHit;
    public UnityEvent OnStunEnd;
    public bool isHitStun;

    public bool immortal;


    public CollisionInfo info;

    public void DealDamage(int dmg)
    {
        if (!isHitStun)
        {
           

            if (!immortal)
                life -= dmg;

            OnHit.Invoke();
            StartCoroutine(HitStun());
            if (life <= 0)
            {

                OnDeath.Invoke();
            }
        }
        else
        {
            return;
        }



    }


    public void DealDamage(CollisionInfo i)
    {
       

        if (!isHitStun)
        {
            info = i;
            

            if (!immortal)
                life -= info.totalDmg;
            OnHit.Invoke();
            StartCoroutine(HitStun());
            if (life <= 0)
            {

                OnDeath.Invoke();
            }
        }
        else
        {
            return;
        }





    }

    IEnumerator HitStun()
    {
        isHitStun = true;
        yield return new WaitForSeconds(0.5f);
        isHitStun = false;
        OnStunEnd.Invoke();
    }



    public class CollisionInfo
    {
        public Vector2 position;
        public int totalDmg;


        
        


    }
}
