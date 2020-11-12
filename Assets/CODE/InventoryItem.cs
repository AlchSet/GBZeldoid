using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour {



    public WeaponBase weapon;

    public bool isEmpty;

    public int id = 0;

    public bool unlocked = false;
    public Sprite lockedSprite;


    Image img;

    Sprite osprite;
    //public UnityEvent SelectItem;

    // Use this for initialization
    void Awake() { 
        img = GetComponent<Image>();
        osprite = img.sprite;
        if (!unlocked)
        {
            img.sprite = lockedSprite;
        }
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnEnable()
    {
        if(unlocked)
            img.sprite = osprite;
    }

    public void Unlock()
    {
        Debug.Log("UNLOCK");
        unlocked = true;
        //img.sprite = osprite;
    }
}
