using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportStone : WeaponBase {



    Player player;
    public ParticleSystem p;

    ParticleSystem.EmissionModule em;

    void Start()
    {
        player = transform.root.GetComponent<Player>();
        em = p.emission;

        em.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

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
        Debug.Log("TELEPORT");
        StartCoroutine(TeleportPlayer());
    }

    public override void OnButtonUp()
    {
        throw new System.NotImplementedException();
    }



    IEnumerator TeleportPlayer()
    {
        //player.playerSprite.enabled = false;
        player.innerBox.enabled = false;
        player.state = Player.PlayerState.Attacking;
        player.controller.speed = 5;
        em.enabled = true;
        yield return new WaitForSeconds(0.5f);
        em.enabled = false;
        player.controller.speed = 3;
        //player.playerSprite.enabled = true;
        player.innerBox.enabled = true;
        player.state = Player.PlayerState.Normal;
    }
    // Use this for initialization
    
}
