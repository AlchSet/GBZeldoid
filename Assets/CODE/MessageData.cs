using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageData : MonoBehaviour {


    [TextArea]

    public string[] dialogue;

    public int dialogueIndex;

    public bool finish;


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


    public void GetTreeStateMessage(DialogueTreeState s)
    {
        dialogue = s.dialogue;
    }





}
