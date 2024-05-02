namespace Visions.UI {

    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class InGameMenu : MonoBehaviour {

        [SerializeField] private Canvas menuScreen;

        // Used By Menu Buttons
        public void GoToMenu( ) {

            SceneManager.LoadScene( "Menu" );

        }

        public void SetGameMenuState( bool newState ) {

            Cursor.visible = newState;
            menuScreen.enabled = newState;

            if ( newState ) {

                Cursor.lockState = CursorLockMode.None;

            }
            else {

                Cursor.lockState = CursorLockMode.Locked;

            }
        }

        // Start is called before the first frame update
        void Start( ) {

            Cursor.visible = false;

            SetGameMenuState( false );

        }

        void Update( ) {

            if ( Input.GetKeyDown( KeyCode.Escape ) || Input.GetKeyDown( KeyCode.M ) ) {

                SetGameMenuState( !menuScreen.enabled );

            }

        }

    }

}