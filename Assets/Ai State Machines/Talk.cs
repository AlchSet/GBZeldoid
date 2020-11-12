using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : StateMachineBehaviour {

    MyAI ai;


    [TextArea]

    public string[] dialogue;

    public int dialogueIndex;


    DialogueTreeContainer tree;
   


    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ai = animator.GetComponent<MyAI>();
        ai.stopMove = true;
        //Debug.Log(dialogue[dialogueIndex]);
        //ai.talkLock = true;

        tree = animator.transform.root.GetComponent<DialogueTreeContainer>();

     
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    string s = tree.current.getDialogue();

        //    if (s != null)
        //    {
        //        Debug.Log(s);
        //    }
        //    else
        //    {
        //        ai.AiStateMachine.SetTrigger("Continue");
        //    }
            



        //}
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //ai.UnlockTalk();
        //ai.stopMove = false;
    }

   




}
