using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public enum PlayerState { Normal, Swimming, Grabbing, Falling, Attacking, Stunned }

    public bool isNaked;

    public Collider2D innerBox;
    public Collider2D physBox;

    public static int keys;

    public delegate void Action();

    public Action OnAddCash;


    public PlayerState state = PlayerState.Normal;
    public Controller controller;
    Animator anim;

    bool isDiving;

    int mask;


    public Weapon sword;

    public WeaponBase SWORD;
    public WeaponBase BOMB;
    public WeaponBase SHIELD;




    bool freezeMove;

    Vector2 spawnPoint;


    public SpriteRenderer playerSprite;


    float pushTimer;


    Transform pullObject;
    bool isPullingObject;

    public int money;

    public WeaponBase DWPN;
    public WeaponBase CWPN;

    public WeaponBase SWORDSLOT;
    public WeaponBase SHIELDSLOT;

    //public WeaponBase SPACEWPN;

    public bool pause;


    Damageable dmg;


    Vector2 grapOffset;


    public ParticleSystem splash;

    bool PushAgainDelay;

    
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<Controller>();
        anim = GetComponentInChildren<Animator>();

        dmg = GetComponentInChildren<Damageable>();

        controller.OnSwim = StartSwimming;
        controller.OnExitSwim = ExitSwimming;
        controller.OnFallInHole = FallInHole;
        mask = 1 << LayerMask.NameToLayer("Interactable") | 1 << LayerMask.NameToLayer("Movable") | 1 << LayerMask.NameToLayer("NPC");

        sword.OnAttack = FreezePlayer;
        sword.OnExitAttack = UnFreezePlayer;

        spawnPoint = transform.position;
        OnAddCash += Nothing;


        splash = transform.Find("splash").GetComponent<ParticleSystem>();


        innerBox = transform.Find("InnerBox").GetComponent<Collider2D>();
        physBox = transform.Find("PhysBox").GetComponent<Collider2D>();

        playerSprite = transform.Find("CharTest1").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {




        //controller.inputVel = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        controller.SetInputVel(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        switch (controller.facingDir)
        {

            case Directions.North:

                anim.SetFloat("X", 0);
                anim.SetFloat("Y", 1);

                break;
            case Directions.South:

                anim.SetFloat("X", 0);
                anim.SetFloat("Y", -1);

                break;

            case Directions.East:

                anim.SetFloat("X", 1);
                anim.SetFloat("Y", 0);

                break;

            case Directions.West:

                anim.SetFloat("X", -1);
                anim.SetFloat("Y", 0);

                break;
        }
        switch (state)
        {
            case PlayerState.Normal:



                //if(&& !XWPN.GetInUse() && !CWPN.GetInUse() && !SPACEWPN.GetInUse())
                //{




                //}
                if (controller.isMoving)
                {
                    //Debug.Log("NORMAL");
                    

                    if(isNaked)
                    {
                        anim.Play("Naked Move");
                    }
                    else
                    {
                        anim.Play("Move");
                    }

                }
                else
                {
                    if (isNaked)
                    {
                        anim.Play("Idle Naked");
                    }
                    else
                    {
                        anim.Play("Idle");
                    }
                        
                }


                //if (Input.GetKeyDown(KeyCode.X) && sword.isEquiped)
                //{
                //    sword.UseWeapon(controller.facingDir);
                //    state = PlayerState.Attacking;
                //}


                if (!pause)
                {

                    if (Input.GetKeyDown(KeyCode.D) && DWPN != null)
                    {
                        DWPN.OnButtonDown();

                    }
                    if (Input.GetKeyUp(KeyCode.D) && DWPN != null)
                    {
                        DWPN.OnButtonUp();
                    }

                    if (Input.GetKeyDown(KeyCode.C) && CWPN != null)
                    {
                        CWPN.OnButtonDown();
                    }
                    if (Input.GetKeyUp(KeyCode.C) && CWPN != null)
                    {
                        CWPN.OnButtonUp();
                    }


                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        SHIELDSLOT.OnButtonDown();
                    }
                    if (Input.GetKeyUp(KeyCode.Z))
                    {
                        SHIELDSLOT.OnButtonUp();
                    }


                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        SWORDSLOT.OnButtonDown();
                        SHIELDSLOT.Dispose();
                    }
                    if (Input.GetKeyUp(KeyCode.X))
                    {
                        SWORDSLOT.OnButtonUp();
                    }



                    //if (Input.GetKeyDown(KeyCode.Space) && SPACEWPN != null)
                    //{
                    //    SPACEWPN.OnButtonDown();
                    //}
                    //if (Input.GetKeyUp(KeyCode.Space) && SPACEWPN != null)
                    //{
                    //    SPACEWPN.OnButtonUp();
                    //}



                }


                RaycastHit2D hit = Physics2D.Raycast(transform.position, controller.facingDirection, 1f, mask);

                Debug.DrawRay(transform.position, controller.facingDirection * 1, Color.yellow);
                if (hit.collider != null)
                {
                    Debug.Log("Something's there " + hit.collider.name);
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            hit.collider.GetComponent<Interactable>().Interact();
                        }


                    }

                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Movable"))
                    {
                        //Debug.Log("movable AT "+hit.distance);


                        pullObject = hit.collider.transform;



                        if (Input.GetKeyDown(KeyCode.Space) && !isPullingObject && state != PlayerState.Falling&&!PushAgainDelay)
                        {

                            SHIELDSLOT.OnButtonUp();
                            grapOffset = transform.position - pullObject.position;

                            GrabObject();
                            controller.speed = 1.5f;
                            //controller.lockDirection = true;

                            //isPullingObject = true;
                        }


                    }

                    else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("NPC"))
                    {
                        //Debug.Log("NPC INFRONT");
                        

                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            SHIELDSLOT.OnButtonUp();
                            hit.collider.GetComponent<TalkNPC>().Talk();

                        }

                    }


                }


                break;




            case PlayerState.Attacking:


                break;


            case PlayerState.Swimming:

                isDiving = Input.GetKey(KeyCode.Space);


                if (isDiving)
                {
                    anim.Play("Dive");

                }
                else
                {
                    anim.Play("Swim");
                }


                break;

            case PlayerState.Grabbing:


                if (controller.isMoving)
                {
                    anim.Play("Grab");
                }
                else
                {
                    anim.Play("GrabIdle");
                }

                if (isPullingObject)
                {

                    pullObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    controller.lockDirection = true;

                    //pullObject.GetComponent<Rigidbody2D>().velocity = controller.rigidbody.velocity;


                    //Vector2 npos = (Vector2)transform.position + controller.facingDirection * 0.95f;
                    Vector2 npos = (Vector2)transform.position + controller.facingDirection * 0.85f;
                    //Vector2 npos = (Vector2)transform.position + (grapOffset*1f)+ controller.facingDirection * 0.55f;

                    npos.x = Mathf.Round(npos.x * 16) / 16;
                    npos.y = Mathf.Round(npos.y * 16) / 16;


                    //transform.x = Mathf.Round(transform.x * 100f) / 100f;

                    pullObject.GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pullObject.transform.position,npos,Time.deltaTime*5));

                    float distance = Vector2.Distance(transform.position, pullObject.position);

                    if (Input.GetKeyUp(KeyCode.Space) || distance > 1.25f || !pullObject.GetComponent<Collider2D>().enabled)
                    {

                        LeaveGrabObject();
                        controller.speed = 3;
                        //pullObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        //pullObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                        //controller.lockDirection = false;
                        //isPullingObject = false;
                    }
                }

                break;


            case PlayerState.Falling:

                break;


            case PlayerState.Stunned:

                anim.Play("Stunned");

                break;

        }











    }


    public void StartSwimming()
    {

        if (isPullingObject)
        {

            LeaveGrabObject();
        }
        splash.Emit(20);
        state = PlayerState.Swimming;
        anim.Play("Swim");

    }

    public void ExitSwimming()
    {
        state = PlayerState.Normal;
    }


    public void FreezePlayer()
    {
        anim.Play("UseItem");
        Debug.Log("ATTACK");
        controller.freeze = true;
        state = PlayerState.Attacking;
    }
    public void UnFreezePlayer()
    {
        if (!controller.inHole)
        {
            anim.Play("Idle");
            controller.freeze = false;
            state = PlayerState.Normal;
        }

    }


    public void FallInHole(Transform p)
    {
        //transform.position = p.position;
        StartCoroutine(HoleSequence(p.position));
        state = PlayerState.Falling;
    }


    IEnumerator HoleSequence(Vector2 pos)
    {
        controller.freeze = true;
        StartCoroutine(MovetoHole(pos));

        if (state == PlayerState.Grabbing)
        {
            LeaveGrabObject();
        }

        anim.Play("FallHole");


        yield return new WaitForSeconds(3);

        controller.inHole = false;

        transform.position = spawnPoint;
        controller.freeze = false;
        state = PlayerState.Normal;
    }

    IEnumerator MovetoHole(Vector2 p)
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, p, Time.deltaTime * 5);
            if (Vector2.Distance(transform.position, p) <= 0)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void EquipSword()
    {


        sword.isEquiped = true;
    }



    public void GrabObject()
    {
        controller.lockDirection = true;

        isPullingObject = true;

        state = PlayerState.Grabbing;

    }

    public void LeaveGrabObject()
    {
        pullObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        pullObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        controller.lockDirection = false;
        isPullingObject = false;
        state = PlayerState.Normal;
        StartCoroutine(GrabDelay());
    }

    public void AddMoney(int cash)
    {
        money += cash;
        OnAddCash();
    }

    public void AddKey(int key)
    {
        Player.keys += key;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log(collision.name);

        if (collision.gameObject.tag == "Arrow")
        {
            //ContactFilter2D filter = new ContactFilter2D();
            //Collider2D[] cols = new Collider2D[2];


            //collision.OverlapCollider(filter, cols);

            //foreach (Collider2D d in cols)
            //{
            //    Debug.Log(d.name);
            //}

            Damageable.CollisionInfo i = new Damageable.CollisionInfo();
            i.position = collision.transform.position;
            i.totalDmg = 1;


            dmg.DealDamage(i);

            Debug.Log("OUCH");
            Destroy(collision.gameObject);
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Damageable.CollisionInfo i = new Damageable.CollisionInfo();
            i.position = collision.transform.position;
            i.totalDmg = 1;


            dmg.DealDamage(i);

            Debug.Log("OUCH");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.name);
        //if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        //{
        //    Damageable.CollisionInfo i = new Damageable.CollisionInfo();
        //    i.position = collision.contacts[0].point;
        //    i.totalDmg = 1;


        //    dmg.DealDamage(i);

        //    Debug.Log("OUCH");

        //}
        //Debug.Log(collision.collider.name);
    }


    void Nothing()
    { }

    public void BindSwordToX()
    {
        DWPN = SWORD;
    }


    public void PlayHitStun()
    {

        StartCoroutine(HitStun());

        //if(!dmg.isHitStun)
        //{

        //}
    }

    IEnumerator HitStun()
    {
        controller.enabled = false;
        PlayerState lastState = state;
        state = PlayerState.Stunned;
        yield return new WaitForSeconds(.5f);
        controller.enabled = true;
        if (lastState == PlayerState.Attacking)
        {
            state = PlayerState.Normal;
        }
        else
        {
            state = lastState;
        }

    }


    IEnumerator GrabDelay()
    {
        PushAgainDelay = true;

        yield return new WaitForSeconds(1);

        PushAgainDelay = false;



    }



    public void SetIsNaked(bool naked)
    {
        isNaked = naked;
    }

}
