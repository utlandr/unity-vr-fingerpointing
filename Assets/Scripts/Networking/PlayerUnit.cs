using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUnit : NetworkBehaviour
{

    public GameObject playerCamera = null;

    // Setup components to ban (scripts and things)
    [SerializeField]
    private Behaviour[] componentsToDisable;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer == false)
        {
            for ( int i = 0; i < componentsToDisable.Length; i++ )
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else{

        }    
    }

    // Update is called once per frame
    void Update()
    {
        if( isLocalPlayer == false )
        {
            return;
        }


    }
}
