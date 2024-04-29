using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    
    void Start( ) {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
    public void ChangeScene( string sceneName ) {

        LevelManager.Instance.LoadScene( sceneName  );

    }

    public void ExitGame( ) {

        Application.Quit( );

    }
}
