using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject teleportLocation;
    private Transform thePlayer;

    public void TeleportPlayer( ) {

        CharacterController cc = thePlayer.GetComponent< CharacterController >( );

        cc.enabled = false;
        thePlayer.transform.rotation = teleportLocation.transform.rotation;
        thePlayer.transform.position = teleportLocation.transform.position;
        cc.enabled = true;
    
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        thePlayer = transform.Find( "PlayerCapsule" );

    }

    // Update is called once per frame
    void Update()
    {
        
        if ( Input.GetKeyDown( KeyCode.Y ) ) {

            TeleportPlayer( );
            
        }
    }
}
