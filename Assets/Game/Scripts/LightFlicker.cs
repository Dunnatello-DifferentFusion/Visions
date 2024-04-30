namespace Visions.Environment {
    
    using System.Collections;
    using UnityEngine;

    public class LightFlicker : MonoBehaviour {

        private Light lightObject;
        [SerializeField] private float flickerDelay = 0.1f;
        [SerializeField] private float flickerFrequencyDecrease = 1.3f;
        [SerializeField] private float baseFlickerFrequency = 0.5f;

        private float currentFlickerFrequency;
        private int decreases = 0;

        private void Start( ) {
            lightObject = GetComponent<Light>( );
        }

        // Update is called once per frame
        private void Update( ) {

            if ( decreases > 5 ) {
                decreases = 0;
            }

            if ( currentFlickerFrequency <= 0 ) {
                StartCoroutine( Flicker( flickerDelay ) );
                currentFlickerFrequency = Random.Range( baseFlickerFrequency, baseFlickerFrequency + flickerFrequencyDecrease * decreases );
                decreases++;
            }
            else {
                currentFlickerFrequency -= Time.deltaTime;
            }

        }

        private IEnumerator Flicker( float delay ) {
            lightObject.enabled = false;
            yield return new WaitForSeconds( delay );
            lightObject.enabled = true;
        }

    }

}