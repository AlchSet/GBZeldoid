using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : WeaponBase
{


    public GameObject bowNorth, bowSouth, bowEast, bowWest;
    Controller rootControl;
    public GameObject arrow;
    GameObject g;

    Vector3 force;
    void Start()
    {
        rootControl = transform.root.GetComponent<Controller>();
        bowNorth.SetActive(false);
        bowSouth.SetActive(false);
        bowEast.SetActive(false);
        bowWest.SetActive(false);
    }

    public override void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public override bool GetInUse()
    {
        throw new System.NotImplementedException();
    }

    public override void OnButtonDown()
    {
        rootControl.lockDirection = true;
        switch (rootControl.facingDir)
        {
            case Directions.North:
                bowNorth.SetActive(true);
                bowSouth.SetActive(false);
                bowEast.SetActive(false);
                bowWest.SetActive(false);
                g = Instantiate(arrow, bowNorth.transform.position, Quaternion.Euler(0,0,90));
                g.transform.SetParent(transform, true);
                force = Vector2.up * 5;
                break;

            case Directions.South:
                bowNorth.SetActive(false);
                bowSouth.SetActive(true);
                bowEast.SetActive(false);
                bowWest.SetActive(false);
                g = Instantiate(arrow, bowSouth.transform.position, Quaternion.Euler(0, 0, 270));
                g.transform.SetParent(transform, true);
                force = Vector2.down * 5;
                break;

            case Directions.East:
                bowNorth.SetActive(false);
                bowSouth.SetActive(false);
                bowEast.SetActive(true);
                bowWest.SetActive(false);
                g = Instantiate(arrow, bowEast.transform.position, Quaternion.Euler(0, 0, 0));
                g.transform.SetParent(transform, true);
                force = Vector2.right * 5;
                break;

            case Directions.West:
                bowNorth.SetActive(false);
                bowSouth.SetActive(false);
                bowEast.SetActive(false);
                bowWest.SetActive(true);
                g = Instantiate(arrow, bowWest.transform.position, Quaternion.Euler(0, 0, 180));
                g.transform.SetParent(transform,true);
                force = Vector2.left * 5;
                break;

        }

    }

    public override void OnButtonUp()
    {
        rootControl.lockDirection = false;
        bowNorth.SetActive(false);
        bowSouth.SetActive(false);
        bowEast.SetActive(false);
        bowWest.SetActive(false);

        g.transform.SetParent(null);

        Rigidbody2D r = g.GetComponent<Rigidbody2D>();
        r.bodyType = RigidbodyType2D.Dynamic;
        r.AddForce(force, ForceMode2D.Impulse);

    }

    // Use this for initialization


    // Update is called once per frame
    void Update()
    {

    }
}
