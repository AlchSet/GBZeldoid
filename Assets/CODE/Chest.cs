using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour, Interactable
{


    bool isOpened;

    SpriteRenderer sprite;

    public Sprite closedSprite;
    public Sprite openedSprite;

    public Transform lootGraphic;

    public UnityEvent OnOpenChest;


    // Use this for initialization
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Interact()
    {
        if (!isOpened)
        {
            Debug.Log("RECEIVED SWORD");

            sprite.sprite = openedSprite;

            StartCoroutine(OpenChest());
            isOpened = true;
        }

    }



    IEnumerator OpenChest()
    {
        Vector2 m = (Vector2)lootGraphic.position + Vector2.up * 1.5f;
        Vector2 o = lootGraphic.position;
        float i = 0;
        while(true)
        {
            i += Time.deltaTime*2f;
            lootGraphic.position = Vector2.Lerp(o, m, i);

            if (i >= 1)
                break;

            yield return new WaitForEndOfFrame();

        }
        OnOpenChest.Invoke();
        yield return new WaitForSeconds(1.5f);
        lootGraphic.gameObject.SetActive(false);

        yield return null;
    }

}
