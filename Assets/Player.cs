using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();
    

    [Client]
    void Update()
    {
        if (!hasAuthority) { return; }
        
        if(!Input.GetKeyDown(KeyCode.Space)) { return; }

        CmdMove();
        //transform.Translate(movement);
    }


    [Command]
    private void CmdMove()
    {
        //Validate logic here
        RpcMove();
    }

    [ClientRpc]
    private void RpcMove()
    {
        transform.Translate(movement);
    }
}
