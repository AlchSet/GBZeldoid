using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkNPC : MonoBehaviour {

    public MyAI ai;
    public DialogueTreeContainer tree;
    public MessagePanel panel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Talk()
    {
        if(!ai.talkLock)
        {
            ai.talkLock = true;
            //Debug.Log(tree.current);
            panel.StartDialogue(tree.current,EndTalk);
            ai.AiStateMachine.SetTrigger("Talk");
            //panel.OnEndTalk += EndTalk;
        }
        //Debug.Log("BLA");
        
    }


    public void EndTalk()
    {
        ai.AiStateMachine.SetTrigger("Continue");
        panel.OnEndTalk -= EndTalk;
        ai.UnlockTalk();
    }

}
