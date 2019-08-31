using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUnit : NetworkBehaviour
{
    
    [SerializeField]
    Behaviour[] componentsToDisable;

    // Start is called before the first frame update
    void Start()
    {
        if( isLocalPlayer == false )
            {
                Debug.Log("PlayerUnit::Start -- Disabled components on PlayerUnit prefab");
                for ( int i = 0; i < componentsToDisable.Length; i++ )
                {
                    componentsToDisable[i].enabled = false;
                }
            }
    }
}
