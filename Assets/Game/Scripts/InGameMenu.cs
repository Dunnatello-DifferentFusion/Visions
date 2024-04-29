using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    public Canvas menuScreen;

    public void goToMenu( ) {

        SceneManager.LoadScene( "Menu" );

    }

    public void setGameMenuState( bool newState ) {

        Cursor.visible = newState;
        menuScreen.enabled = newState;

        print( menuScreen.enabled );
        
        if ( newState ) {

            Cursor.lockState = CursorLockMode.None;

        } else {

            Cursor.lockState = CursorLockMode.Locked;

        }
    }

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;

        setGameMenuState( false );

    }

    void Update( ) {
        
        if ( Input.GetKeyDown( "escape" ) || Input.GetKeyDown( "m" ) ) {

            setGameMenuState( !menuScreen.enabled );

        }

    }

}
