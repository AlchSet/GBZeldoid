using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTreeState : StateMachineBehaviour
{
    [TextArea]

    public string[] dialogue;

    public int dialogueIndex;

    DialogueTreeContainer tree;

    public bool finish;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        tree = animator.transform.root.GetComponent<DialogueTreeContainer>();

        tree.current = this;



    }

    public string getDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex <= dialogue.Length - 1)
        {


            return dialogue[dialogueIndex];
        }
        else
        {
            //Debug.Log("END");
            finish = true;
            dialogueIndex = 0;
            return null;
            //ai.AiStateMachine.SetTrigger("Continue");

        }
    }

}
