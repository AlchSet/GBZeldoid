using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : StateMachineBehaviour
{
    MyAI ai;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai = animator.GetComponent<MyAI>();
        ai.OnFinishPath = NextPoint;

        
        Vector2 p = Random.insideUnitCircle.normalized;
        p = p * 2;
        p = (Vector2)animator.transform.position + p;


        NNInfo info = AstarPath.active.GetNearest(p);

        Vector3 closest = info.position;

       

        ai.SetDestination(closest);

    }


    public void NextPoint()
    {
        Vector2 p = Random.insideUnitCircle.normalized;
        p = p * 2;
        p = (Vector2)ai.transform.position + p;


        NNInfo info = AstarPath.active.GetNearest(p);

        Vector3 closest = info.position;



        ai.SetDestination(closest);

    }



}
