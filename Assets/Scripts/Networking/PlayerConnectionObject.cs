using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;


public class PlayerConnectionObject : NetworkBehaviour
{
    public GameObject PlayerUnitPrefab;
    
    // Setup components/objects to disable (i.e. only the
    // local client instance should have)
    [SerializeField]
    Behaviour[] componentsToDisable;


    void Start()
    {
        if (isLocalPlayer == false)
        {
            for ( int i = 0; i < componentsToDisable.Length; i++ )
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {

        }    
        // Spawn unit
        Debug.Log("PlayerObject::Start -- VR Unit has entered the scene.");
        CmdSpawnMyUnit();
    }

    void Update()
    {
        if( isLocalPlayer == false)
        {
            return;
        }

    }

    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject go = Instantiate(PlayerUnitPrefab);
        go.transform.position = this.transform.position;
        go.transform.rotation = this.transform.rotation;
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }

}
