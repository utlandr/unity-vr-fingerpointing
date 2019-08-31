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
        
        // So apparently the animation doesn't work unless you disable then 
        // reenable. I am definitely doing something wrong but since it works
        // im giving in to this shitty solution
        else
        {
            // Disable
            componentsToDisable[9].enabled = false;
            componentsToDisable[10].enabled = false;

            // Enable
            componentsToDisable[9].enabled = true;
            componentsToDisable[10].enabled = true;

        }
    }
}
