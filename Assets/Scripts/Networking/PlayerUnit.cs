using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerUnit : NetworkBehaviour
{
    
    [Header("Local controller only objects")]
    [SerializeField]
    public Behaviour[] componentsToDisable;
    
    [Space(10)]
    [Header("Root Humanoid Model object")]
    public GameObject trackBody; 
    
    //Awake to create tracked child components
    void Awake()
    {            
        // Transform[] childList = trackBody.GetComponentsInChildren<Transform>();

        // // Adding alot of components on a single object... not sure if it will work
        // // TODO: Think about how to do this better.
        // for(int i=1; i < childList.Length; i++)
        // {
        //     NetworkTransformChild newTransformChild = gameObject.AddComponent<NetworkTransformChild>(); 
        //     newTransformChild.target = childList[i].transform;
        //     newTransformChild.enabled = true;
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        if( isLocalPlayer == false )
        {
                Debug.Log("PlayerUnit::Start -- Disabled components on PlayerUnit prefab");
                for ( int i = 0; i < componentsToDisable.Length; i++ )
                {
                    if(componentsToDisable[i] != null)
                    {
                        componentsToDisable[i].enabled = false;
                    }
                }
        }
        else
        {
            if(trackBody != null)
            {
                // So apparently the animation doesn't work unless you disable then 
                // reenable (???). This probably has to do with the fact that I am using multiple animators
                // on a single player mesh instead of just one single animator. However, it works for our purposes so
                // the hacky solution stays...

                // Disable
                componentsToDisable[9].enabled = false;
                componentsToDisable[10].enabled = false;

                // Enable
                componentsToDisable[9].enabled = true;
                componentsToDisable[10].enabled = true;
            }
        }
    }
}
