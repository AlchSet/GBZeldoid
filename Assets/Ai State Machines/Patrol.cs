using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Patrol : StateMachineBehaviour
{
    public enum PatrolMode { OneWay, Looping, PingPong, Random }
    public PatrolMode mode = PatrolMode.Looping;

    Animator statemachine;

    public int routeSelect;
    RouteList routelist;
    //Seeker seeker;
    public int waypointIndex = 0;

    MyAI ai;

    bool hasEnded;
    bool alreadySubbed;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        hasEnded = false;
        waypointIndex = 0;

        routelist = animator.GetComponent<RouteList>();
        ai = animator.GetComponent<MyAI>();

        if(!alreadySubbed)
        {
            ai.OnFinishPath += NextPoint;
            alreadySubbed = true;
        }
       
        statemachine = animator;
        ai.SetDestination(routelist.routes[routeSelect].GetGlobalPoint(waypointIndex));
        ai.stopMove = false;


    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {

    }


    public void NextPoint()
    {


        //Debug.Log("NEXT POINT");

        switch (mode)
        {
            case PatrolMode.Looping:
                waypointIndex = (waypointIndex + 1) % routelist.routes[routeSelect].Points.Length;
                ai.SetDestination(routelist.routes[routeSelect].GetGlobalPoint(waypointIndex));
                break;

            case PatrolMode.OneWay:

                if (waypointIndex < routelist.routes[routeSelect].Points.Length - 1)
                {
                    waypointIndex = Mathf.Clamp(waypointIndex + 1, 0, routelist.routes[routeSelect].Points.Length);
                    ai.SetDestination(routelist.routes[routeSelect].GetGlobalPoint(waypointIndex));
                }
                else
                {
                    if (!hasEnded)
                    {
                        statemachine.SetTrigger("Continue");
                        hasEnded = true;
                    }
                }



                break;
        }


    }

}
