using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : WeaponBase
{


    GameObject shield;

    public GameObject[] shieldPoses;


    Controller rootControl;


    Rigidbody2D spikeblock;
    bool b;

    // Use this for initialization
    void Start()
    {
        //shield = transform.Find("EvilShield").gameObject;

        rootControl = transform.root.GetComponent<Controller>();


        shieldPoses[0].SetActive(false);
        shieldPoses[1].SetActive(false);
        shieldPoses[2].SetActive(false);
        shieldPoses[3].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //bool b = Input.GetKey(KeyCode.C);


        if(Time.timeScale==0)
        {
            b = false;
        }

        if (b)
        {

            switch (rootControl.facingDir)
            {
                case Directions.North:

                    shieldPoses[0].SetActive(false);
                    shieldPoses[1].SetActive(true);
                    shieldPoses[2].SetActive(false);
                    shieldPoses[3].SetActive(false);



                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1, 1 << LayerMask.NameToLayer("Spikeblock"));


                    if (hit)
                    {

                        if (hit.collider.tag == "SpikeBlock")
                        {
                            Debug.Log("Spikeblock infront");

                            spikeblock = hit.collider.GetComponent<Rigidbody2D>();


                            Vector2 npos = (Vector2)hit.collider.transform.position + Vector2.up * 1.25f * Time.deltaTime;

                            //Vector2 npos = (Vector2)transform.position + Vector2.facingDirection * 0.95f;

                            npos.x = Mathf.Round(npos.x * 16) / 16;
                            npos.y = Mathf.Round(npos.y * 16) / 16;


                            //transform.x = Mathf.Round(transform.x * 100f) / 100f;
                            spikeblock.bodyType = RigidbodyType2D.Dynamic;
                            spikeblock.MovePosition(npos);



                        }

                    }



                    break;

                case Directions.South:


                    shieldPoses[0].SetActive(true);
                    shieldPoses[1].SetActive(false);
                    shieldPoses[2].SetActive(false);
                    shieldPoses[3].SetActive(false);



                    hit = Physics2D.Raycast(transform.position, Vector2.down, 1, 1 << LayerMask.NameToLayer("Spikeblock"));


                    if (hit)
                    {

                        if (hit.collider.tag == "SpikeBlock")
                        {
                            Debug.Log("Spikeblock infront");

                            spikeblock = hit.collider.GetComponent<Rigidbody2D>();


                            Vector2 npos = (Vector2)hit.collider.transform.position + Vector2.down * 1.5f * Time.deltaTime;

                            //Vector2 npos = (Vector2)transform.position + Vector2.facingDirection * 0.95f;

                            npos.x = Mathf.Round(npos.x * 16) / 16;
                            npos.y = Mathf.Round(npos.y * 16) / 16;


                            //transform.x = Mathf.Round(transform.x * 100f) / 100f;
                            spikeblock.bodyType = RigidbodyType2D.Dynamic;
                            spikeblock.MovePosition(npos);



                        }

                    }




                    break;
                case Directions.East:
                    shieldPoses[0].SetActive(false);
                    shieldPoses[1].SetActive(false);
                    shieldPoses[2].SetActive(true);
                    shieldPoses[3].SetActive(false);


                    hit = Physics2D.Raycast(transform.position, Vector2.right, 1, 1 << LayerMask.NameToLayer("Spikeblock"));


                    if (hit)
                    {

                        if (hit.collider.tag == "SpikeBlock")
                        {
                            Debug.Log("Spikeblock infront");

                            spikeblock = hit.collider.GetComponent<Rigidbody2D>();


                            Vector2 npos = (Vector2)hit.collider.transform.position + Vector2.right * 1.5f * Time.deltaTime;

                            //Vector2 npos = (Vector2)transform.position + Vector2.facingDirection * 0.95f;

                            npos.x = Mathf.Round(npos.x * 16) / 16;
                            npos.y = Mathf.Round(npos.y * 16) / 16;


                            //transform.x = Mathf.Round(transform.x * 100f) / 100f;
                            spikeblock.bodyType = RigidbodyType2D.Dynamic;
                            spikeblock.MovePosition(npos);



                        }

                    }



                    break;
                case Directions.West:
                    shieldPoses[0].SetActive(false);
                    shieldPoses[1].SetActive(false);
                    shieldPoses[2].SetActive(false);
                    shieldPoses[3].SetActive(true);


                    hit = Physics2D.Raycast(transform.position, Vector2.left, 1, 1 << LayerMask.NameToLayer("Spikeblock"));


                    if (hit)
                    {

                        if (hit.collider.tag == "SpikeBlock")
                        {
                            Debug.Log("Spikeblock infront");

                            spikeblock = hit.collider.GetComponent<Rigidbody2D>();


                            Vector2 npos = (Vector2)hit.collider.transform.position + Vector2.left * 1.5f * Time.deltaTime;

                            //Vector2 npos = (Vector2)transform.position + Vector2.facingDirection * 0.95f;

                            npos.x = Mathf.Round(npos.x * 16) / 16;
                            npos.y = Mathf.Round(npos.y * 16) / 16;


                            //transform.x = Mathf.Round(transform.x * 100f) / 100f;
                            spikeblock.bodyType = RigidbodyType2D.Dynamic;
                            spikeblock.MovePosition(npos);



                        }

                    }
                    break;

            }









        }
        else
        {
            try
            {
                spikeblock.bodyType = RigidbodyType2D.Kinematic;
                spikeblock.velocity = Vector2.zero;

            }
            catch (Exception e) { }
            shieldPoses[0].SetActive(false);
            shieldPoses[1].SetActive(false);
            shieldPoses[2].SetActive(false);
            shieldPoses[3].SetActive(false);
        }




        //shield.SetActive(Input.GetKey(KeyCode.C));
    }

    public override void OnButtonDown()
    {
        b = true;
        inAttack = true;
    }

    public override void OnButtonUp()
    {
        //Debug.Log("BTN UP");
        b = false;
        inAttack = false;
    }

    public override bool GetInUse()
    {
        return false;
    }

    public override void Dispose()
    {
        b = false;
        Debug.Log("DISPOSE SHIELD");
    }
}
