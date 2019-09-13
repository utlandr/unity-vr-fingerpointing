using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Ghostify : NetworkBehaviour
{
    public GameObject ghostObject; 
    public float alpha = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer)
        {
            var trans = ghostObject.GetComponent<Renderer>().material.color;
            ghostObject.GetComponent<Renderer>().material.color = new Color(trans.r, trans.g, trans.b, alpha); 
        }

    }

    void Update()
    {
        if(!isLocalPlayer)
        {
            var trans = ghostObject.GetComponent<Renderer>().material.color;
            ghostObject.GetComponent<Renderer>().material.color = new Color(trans.r, trans.g, trans.b, alpha); 
        }
        
    }
    
}
