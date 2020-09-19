using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private Vector3 movement = new Vector3(0,0,0);
    [SerializeField] private Transform spawnPos;


    [Client]
    private void Start()
    {
        transform.position = spawnPos.position;
    }
    void Update()
    {
        if (!hasAuthority) { return; }

        if (Input.GetKeyDown(KeyCode.W))
        {
            movement = new Vector3(0, 0, 1);
            CmdMove(movement);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movement = new Vector3(0, 0, 1);
            CmdMove(movement);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movement = new Vector3(1, 0, 0);
            CmdMove(movement);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movement = new Vector3(-1, 0, 1);
            CmdMove(movement);
        }
        //transform.Translate(movement);
    }


    [Command]
    private void CmdMove(Vector3 movement)
    {
        //Validate logic here
        RpcMove(movement);
    }

    [ClientRpc]
    private void RpcMove(Vector3 movement)
    {
        transform.Translate(movement);
    }
}
