using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : StateMachineBehaviour {

    Transform player;

    MyAI ai;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai = animator.GetComponent<MyAI>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        float distance = Vector2.Distance(ai.transform.position, player.position);

        //Debug.Log("dist=" + distance);


        if(distance<5)
        {


            ai.SetDestination(player.position);
        }
    }



}
