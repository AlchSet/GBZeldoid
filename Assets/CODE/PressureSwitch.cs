using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : MonoBehaviour, ISwitch
{


    public Sprite sprite1;
    public Sprite sprite2;

    SpriteRenderer renderer;

    public bool state;

    public delegate void Action();

    public Action OnStateTrue;
    public Action OnStateFalse;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        renderer.sprite = sprite1;
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        renderer.sprite = sprite2;
        state = true;
        if (OnStateTrue!=null)
            OnStateTrue();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        renderer.sprite = sprite1;
        state = false;
        if (OnStateFalse != null)
            OnStateFalse();
    }

    public bool GetState()
    {
        return state;
    }
}
