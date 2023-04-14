using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAU : MonoBehaviour
{

    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void ActivateAmongUs( ) {

        character.SetActive( true );

    }
    // Update is called once per frame
    void Update()
    {
        
        if ( Input.GetKeyDown( KeyCode.Equals ) ) {

            ActivateAmongUs( );

        }

    }

}
