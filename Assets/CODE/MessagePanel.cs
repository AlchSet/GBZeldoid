using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{

    DialogueTreeState currentDialogue;

    public Player player;


    TextMeshProUGUI messageText;


    public bool process;


    public delegate void Action();

    public Action OnEndTalk;

    CanvasGroup g;


    MessageData mdata;

    // Use this for initialization
    void Start()
    {
        messageText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        g = GetComponent<CanvasGroup>();
        g.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (process)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("PROCESSING");
                //string s = currentDialogue.getDialogue();
                string s = mdata.getDialogue();

                if (s != null)
                {
                    messageText.text = s;
                }
                else
                {
                    Debug.Log("END");
                    process = false;
                    g.alpha = 0;

                    if (player)
                        player.UnFreezePlayer();

                    if (OnEndTalk != null)
                    {
                      
                        OnEndTalk();
                    }//ai.AiStateMachine.SetTrigger("Continue");
                }






            }

        }
    }



    public void StartDialogue(DialogueTreeState dialogue, Action a)
    {
        g.alpha = 1;
        currentDialogue = dialogue;
        mdata = new MessageData();

        mdata.GetTreeStateMessage(dialogue);

        OnEndTalk += a;
        //Debug.Log(currentDialogue.dialogue[0]);

        messageText.text = currentDialogue.dialogue[0];


        StartCoroutine(InputDelay());
        if (player)
            player.FreezePlayer();

        //process = true;

        //Debug.Log("PROCESS= " + process);
    }


    public void StartMessage(MessageData m)
    {
        g.alpha = 1;
        mdata = m;

        messageText.text = m.dialogue[0];
        if (player)
            player.FreezePlayer();
        StartCoroutine(InputDelay());
    }

    IEnumerator InputDelay()
    {
        yield return new WaitForSeconds(0.1f);

        process = true;
    }





    //public class MessageData
    //{

    //}




}
