namespace Visions.Player {

    using UnityEngine;
    using UnityEngine.SceneManagement;
    using TMPro;

    public class Health : MonoBehaviour {

        [SerializeField] private float PlayerHealth = 100;
        [SerializeField] private TextMeshProUGUI healthText;

        private readonly float recentlyDamaged = 3.0f;
        private float delayRemaining;

        [SerializeField] UI.Blood bloodReference;

        private void UpdateUI( ) {
            healthText.text = ( ( int ) PlayerHealth ).ToString( );
        }
        public void TakeDamage( float damage ) {

            PlayerHealth -= damage;
            delayRemaining = recentlyDamaged;
            UpdateUI( );
            bloodReference.DamageTaken( );

            if ( PlayerHealth <= 20 ) {
                healthText.color = new Color( 255, 0, 0, 255 );
            }

        }

        void Update( ) {

            // End Game
            if ( PlayerHealth <= 0 ) {
                SceneManager.LoadScene( "Credits" );
                return;
            }

            // Regenerate Health
            if ( delayRemaining <= 0 && PlayerHealth <= 100 ) {

                PlayerHealth += Time.deltaTime * 10;

                UpdateUI( );

                if ( PlayerHealth > 20 ) {
                    healthText.color = new Color( 255, 255, 255, 255 );
                }

            }
            else {
                delayRemaining -= Time.deltaTime;
            }

            // Handle Health Overflow
            if ( PlayerHealth > 100 )
                PlayerHealth = 100;

        }

    }

}