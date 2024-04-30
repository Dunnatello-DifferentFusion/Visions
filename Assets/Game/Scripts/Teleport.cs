namespace Visions.Player {
    
    using UnityEngine;

    public class Teleport : MonoBehaviour {

        public GameObject teleportLocation;
        private Transform thePlayer;
        [SerializeField] private bool isTesting = false;

        public void TeleportPlayer( ) {

            CharacterController cc = thePlayer.GetComponent<CharacterController>( );

            cc.enabled = false;
            thePlayer.transform.SetPositionAndRotation( teleportLocation.transform.position, teleportLocation.transform.rotation );
            cc.enabled = true;

        }

        // Start is called before the first frame update
        private void Start( ) {

            thePlayer = transform.Find( "PlayerCapsule" );

        }

        // Update is called once per frame
        private void Update( ) {

            // Debug Testing
            if ( Input.GetKeyDown( KeyCode.Y ) && isTesting ) {

                TeleportPlayer( );

            }

        }

    }

}