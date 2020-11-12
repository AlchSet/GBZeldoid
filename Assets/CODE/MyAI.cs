using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class MyAI : MonoBehaviour
{
    public Transform targetPosition;

    Seeker seeker;

    public Path path;

    public float speed = 2;

    public float nextWaypointDistance = 3;

    public int currentWaypoint = 0;

    public bool reachedEndOfPath;

    Controller controller;

    public Animator anim;

    public Animator AiStateMachine;

    public delegate void Action();


    public bool stopMove;

    bool finishPath;

    public Action OnFinishPath;

    public bool talkLock;

    // Use this for initialization
    void Awake()
    {
        seeker = GetComponent<Seeker>();
        //seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);

        controller = GetComponent<Controller>();
        OnFinishPath += DefaultMethod;

        AiStateMachine = GetComponent<Animator>();

    }


    void DefaultMethod()
    {

    }


    public void OnPathComplete(Path p)
    {
        //Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);

        if (!p.error)
        {
            path = p;

            currentWaypoint = 0;
        }
    }


    public void SetDestination(Vector2 newPos)
    {
        reachedEndOfPath = false;
        seeker.StartPath(transform.position, newPos, OnPathComplete);
    }

    private void Update()
    {
        if (path == null)
        {
            controller.inputVel = Vector2.zero;
            return;
        }

        reachedEndOfPath = false;

        float distanceToWaypoint;

        while (true)
        {
            distanceToWaypoint = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

            if (distanceToWaypoint < nextWaypointDistance)
            {

                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    OnFinishPath();
                    //finishPath = true;
                    reachedEndOfPath = true;
                    break;
                }

            }
            else
            {
                break;
            }


        }

        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;

        //Debug.Log(speedFactor);

        if(!stopMove&&!reachedEndOfPath)
        {
            Vector2 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

            Vector2 velocity = dir * speed * speedFactor;

            controller.inputVel = velocity;


        }
        else
        {
            controller.inputVel = Vector2.zero;

        }



        if (controller.isMoving)
        {
            //Debug.Log("NORMAL");
            anim.Play("Move");
        }
        else
        {
            anim.Play("Idle");
        }



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



        if(!stopMove)
        {
            //controller.speed = speed;

            //transform.position += (Vector3)velocity * Time.deltaTime;

            //Debug.Log("MOVE");


            //controller.rigidbody.MovePosition((Vector2)transform.position + velocity);
        }
        //controller.speed = speed * speedFactor;
     


        //MOVE





    }

    public void UnlockTalk()
    {
        StartCoroutine(ReleaseTalkLock());
    }
    IEnumerator ReleaseTalkLock()
    {
        yield return new WaitForSeconds(2);
        talkLock = false;

    }
}
