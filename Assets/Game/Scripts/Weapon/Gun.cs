namespace Visions.Weapon {

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class Gun : MonoBehaviour {
        [Header( "References" )]
        [SerializeField] private GunData gunData;
        [SerializeField] private Transform muzzle;
        [SerializeField] private GameObject bullet;

        private float timeSinceLastShot;

        // UI
        [Header( "UI" )]

        [SerializeField] private TextMeshProUGUI magSize;
        [SerializeField] private TextMeshProUGUI currentAmmo;
        [SerializeField] private TextMeshProUGUI reloadText;

        // Audio
        [Header( "Audio" )]
        [SerializeField] private AudioSource soundPlayer;
        private bool hasPlayedGunEmptySound = false;

        [Serializable]
        public class GunSound {

            public string soundName;
            public AudioClip sound;

        }

        [SerializeField] private List<GunSound> soundList = new( );
        [SerializeField] private Dictionary<string, AudioClip> soundsToPlay = new( );

        private void UpdateUI( ) {

            magSize.text = ( gunData.magSize ).ToString( );
            currentAmmo.text = ( gunData.currentAmmo ).ToString( );

        }

        private void PlaySound( string soundName ) {

            if ( soundName == "Empty" ) {

                if ( hasPlayedGunEmptySound ) {

                    return;

                }

                currentAmmo.color = new Color( 255, 0, 0, 255 );

                hasPlayedGunEmptySound = true;

            }


            soundPlayer.clip = soundsToPlay[ soundName ];
            soundPlayer.Play( );


        }

        private void Start( ) {

            PlayerShoot.shootInput += Shoot;
            PlayerShoot.reloadInput += StartReload;

            reloadText.enabled = false;

            gunData.currentAmmo = gunData.magSize;
            foreach ( var soundPair in soundList ) {

                soundsToPlay[ soundPair.soundName ] = soundPair.sound;

            }

            UpdateUI( );
        }
        public void StartReload( ) {
            if ( !gunData.reloading ) {
                StartCoroutine( Reload( ) );
            }
        }

        private IEnumerator Reload( ) {

            reloadText.enabled = true;

            gunData.reloading = true;
            yield return new WaitForSeconds( gunData.reloadTime );
            gunData.currentAmmo = gunData.magSize;
            gunData.reloading = false;
            hasPlayedGunEmptySound = false;

            reloadText.enabled = false;

            UpdateUI( );
            currentAmmo.color = new Color( 255, 255, 255, 255 );

        }
        private bool CanShoot( ) => !gunData.reloading && timeSinceLastShot > 1f / ( gunData.fireRate / 60f );
        public void Shoot( ) //might not want it to be ienumerator
        {

            int currentIndex = 0;

            if ( gunData.currentAmmo > 0 ) {

                if ( CanShoot( ) ) {
                    _ = Instantiate<GameObject>( bullet, muzzle.position, muzzle.rotation );

                    Vector3 initPos = muzzle.position;
                    Vector3 currPos = initPos;
                    Vector3 endPos;

                    float timeIncrement = 0.06f;
                    float time = timeIncrement;

                    Ray r = new( muzzle.position, transform.forward );

                    float xVel = ( r.GetPoint( gunData.bulletSpeed ) - currPos ).x;
                    float yVel = ( r.GetPoint( gunData.bulletSpeed ) - currPos ).y;
                    float zVel = ( r.GetPoint( gunData.bulletSpeed ) - currPos ).z;

                    float newX = currPos.x;
                    float newY;
                    float newZ = currPos.z;

                    PlaySound( "Fire" );

                    while ( currentIndex < 100 ) //for arcing raycast
                    {
                        newX += xVel * timeIncrement;
                        newY = GetHeight( initPos.y, yVel, time );
                        newZ += zVel * timeIncrement;

                        endPos = new Vector3( newX, newY, newZ );

                        Ray currRay = new( currPos, endPos - currPos );
                        Debug.DrawRay( currPos, endPos - currPos, Color.red, 10 );

                        if ( Physics.Raycast( currRay, out RaycastHit hit ) ) {

                            if ( hit.collider.gameObject.CompareTag( "Enemy" ) ) {

                                AI enemyAIreference = hit.collider.GetComponent<AI>( );
                                enemyAIreference.TakeDamage( 20 );

                            }

                        }

                        currPos = endPos;
                        time += timeIncrement;
                        currentIndex++;
                    }


                    gunData.currentAmmo--;

                    UpdateUI( );
                    timeSinceLastShot = 0;
                    OnGunShot( );
                }
            }
            else {

                PlaySound( "Empty" );

            }
        }


        private float GetDistanceOfRay( Vector3 start, Vector3 end ) {
            return ( float ) Mathf.Sqrt( Mathf.Pow( end.x - start.x, 2 ) + Mathf.Pow( end.y - start.y, 2 ) + Mathf.Pow( end.y - start.y, 2 ) );
        }
        private float GetHeight( float currY, float velY, float time ) {
            return ( float ) ( currY + velY * time - 4.9 * time * time );
        }
        private void OnGunShot( ) {

        }
        private void Update( ) {
            timeSinceLastShot += Time.deltaTime;

        }

    }

}