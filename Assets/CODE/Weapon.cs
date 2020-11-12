using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : WeaponBase
{


    public const int PLAYER_LAYER = 11;

    Animator anim;

    


    public delegate void AttackEvent();


    public Hurtbox hitbox;


    public AttackEvent OnAttack;
    public AttackEvent OnExitAttack;

    public bool isEquiped;

    public SpriteRenderer wpnsprite;

    public SortingGroup wpnLayer;

    Controller controller;
    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();

        OnAttack = Nothing;
        OnExitAttack = Nothing;
        controller = transform.root.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {


        //if(Input.GetKeyDown(KeyCode.X))
        //{


        //    anim.Play("Swing", -1, 0f);
        //}
    }


    public void EnableAttacking()
    {
        //Debug.Log("ATTACK");
        inAttack = true;
        hitbox.isActive = true;
        OnAttack.Invoke();
    }

    public void DisableAttacking()
    {
        inAttack = false;
        hitbox.isActive = false;
        OnExitAttack.Invoke();
    }


    public void UseWeapon()
    {
        if (!inAttack)
            anim.Play("Swing", -1, 0f);
    }


    public void UseWeapon(Directions facingDir)
    {

        if (!inAttack)
        {
            switch (facingDir)
            {


                case Directions.North:
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    //wpnsprite.sortingOrder = PLAYER_LAYER - 1;
                    wpnLayer.sortingOrder = PLAYER_LAYER - 1;
                    break;


                case Directions.South:
                    wpnLayer.sortingOrder = PLAYER_LAYER + 1;
                    transform.eulerAngles = new Vector3(0, 0, 180);
                    break;


                case Directions.East:
                    wpnLayer.sortingOrder = PLAYER_LAYER + 1;
                    transform.eulerAngles = new Vector3(0, 0, -90);

                    break;



                case Directions.West:
                    wpnLayer.sortingOrder = PLAYER_LAYER + 1;
                    transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
            }

            anim.Play("Swing", -1, 0f);


        }


    }


    void Nothing()
    {

    }

    public override void OnButtonDown()
    {
        //UseWeapon();
        UseWeapon(controller.facingDir);
    }

    public override void OnButtonUp()
    {
        //throw new System.NotImplementedException();
    }

    public override bool GetInUse()
    {
        return inAttack;
    }

    public override void Dispose()
    {
        //throw new System.NotImplementedException();
    }
}
