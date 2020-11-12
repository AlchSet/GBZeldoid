using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{


    public delegate void Action();

    public delegate void Action2(Transform p);
    public Action OnSwim;
    public Action OnExitSwim;
    public Action2 OnFallInHole;

    public Rigidbody2D rigidbody;

    public Vector2 inputVel;
    public Vector2 lastInputVel;


    Vector2 swimVel;

    public float speed = 3;

    public float swimspeed = 0;

    public bool freeze;




    public Directions facingDir = Directions.South;


    public Vector2 facingDirection;

    public bool isMoving;

    public bool isSwimming;

    public bool inHole;


    public bool lockDirection;


    public Vector2 DEBUGFACEDIR;

    // Use this for initialization
    void Awake()
    {


        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        lastInputVel = Vector2.down;

    }

    // Update is called once per frame
    void Update()
    {


        if (!freeze&&Time.timeScale!=0)
        {

        }  //inputVel = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        else
        {
            inputVel = Vector2.zero;
            rigidbody.velocity = Vector2.zero;
        }

        if (inputVel.magnitude > 0)
        {
            lastInputVel = inputVel;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        //inputVel = new Vector2(Mathf.Round(inputVel.x), Mathf.Round(inputVel.y));

        Vector2 dirVel = new Vector2(Mathf.Round(inputVel.x), Mathf.Round(inputVel.y));

        if (!lockDirection)
        {
            if (Mathf.Abs(dirVel.x) > 0 && dirVel.y == 0)
            {
                //Debug.Log("A");

                facingDirection = new Vector2(lastInputVel.x, 0);



            }
            else if (Mathf.Abs(dirVel.y) > 0 && dirVel.x == 0)
            {

                facingDirection = new Vector2(0, lastInputVel.y);

            }
            else if (Mathf.Abs(dirVel.x) > 0 && Mathf.Abs(dirVel.y) > 0)
            {
                if (facingDir == Directions.North&& dirVel.y<0)
                {
                    facingDirection = new Vector2(0, lastInputVel.y);

                    //Debug.Log("WALKBACKWArDs");




                }
                if (facingDir == Directions.South&& dirVel.y>0)
                {
                    facingDirection = new Vector2(0, lastInputVel.y);

                    ////Debug.Log("WALKBACKWArDs");




                }

                if (facingDir == Directions.East&& dirVel.x<0)
                {
                    facingDirection = new Vector2(0, lastInputVel.y);

                    ////Debug.Log("WALKBACKWArDs");




                }
                if (facingDir == Directions.West&& dirVel.x>0)
                {
                    facingDirection = new Vector2(0, lastInputVel.y);

                    ////Debug.Log("WALKBACKWArDs");




                }



            }


            //Debug.Log(facingDirection.normalized);

            DEBUGFACEDIR = new Vector2(Mathf.Round(facingDirection.x),Mathf.Round(facingDirection.y));
            
            if (facingDirection.normalized == Vector2.right)
            {
                facingDir = Directions.East;
                //sword.transform.eulerAngles = new Vector3(0, 0, -90);
            }
            else if (facingDirection.normalized == Vector2.left)
            {
                facingDir = Directions.West;
                //sword.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else if (facingDirection.normalized == Vector2.down)
            {
                facingDir = Directions.South;
                //sword.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (facingDirection.normalized == Vector2.up)
            {
                facingDir = Directions.North;
                //sword.transform.eulerAngles = new Vector3(0, 0, 180);
            }














        }





    }


    private void FixedUpdate()
    {

        if (!isSwimming)
        {

            //Vector2 targetVel = inputVel * speed/16;
            //rigidbody.MovePosition((Vector2)transform.position + inputVel * 0.0625f);



            Vector2 nPos = (Vector2)transform.position + inputVel * speed * Time.deltaTime;



            swimspeed = 0;
            //nPos.x = Mathf.Round(nPos.x * 16) / 16;
            //nPos.y = Mathf.Round(nPos.y * 16) / 16;

            rigidbody.MovePosition(nPos);

            //Vector2 targetVel = inputVel * speed;

            //Vector2 vel = rigidbody.velocity;

            //Vector2 result = targetVel - vel;

            //rigidbody.AddForce(result, ForceMode2D.Impulse);

        }
        else
        {

            if (isMoving)
            {
                swimspeed = Mathf.MoveTowards(swimspeed, 3, Time.deltaTime * 2);
            }
            else
            {
                swimspeed = Mathf.MoveTowards(swimspeed, 0, Time.deltaTime);
            }

            //swimVel=inputVel*

            Vector2 nPos = (Vector2)transform.position + lastInputVel * swimspeed * Time.deltaTime;

            //nPos.x = Mathf.Round(nPos.x * 16) / 16;
            //nPos.y = Mathf.Round(nPos.y * 16) / 16;

            rigidbody.MovePosition(nPos);



            //Vector2 targetVel = inputVel * speed;

            //Vector2 vel = rigidbody.velocity;

            //Vector2 result = targetVel - vel;

            //rigidbody.AddForce(result, ForceMode2D.Force);



        }





    }

    private void LateUpdate()
    {
        //Vector3 newLocalPosition = Vector3.zero;

        //newLocalPosition.x = (Mathf.Round(transform.position.x * 16) / 16) - transform.position.x;
        //newLocalPosition.y = (Mathf.Round(transform.position.y * 16) / 16) - transform.position.y;

        //rigidbody.MovePosition(newLocalPosition);





    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            isSwimming = true;
            OnSwim.Invoke();
            Debug.Log("Splash");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Holes") && !inHole)
        {
            Debug.Log("FALL INTO HOLE");
            inHole = true;
            OnFallInHole(collision.transform);
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            isSwimming = false;
            OnExitSwim.Invoke();
            //Debug.Log("Splash");
        }
    }


    public void SetInputVel(Vector2 invel)
    {
        if (!freeze)
        {
            inputVel = invel;
        }
        else
        {
            inputVel = Vector2.zero;

        }
    }



}
