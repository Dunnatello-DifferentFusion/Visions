namespace Visions.UI {

    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class Fade : MonoBehaviour {

        private Image blood;
        private readonly float fadeTime = 3.0f;
        private Color originalColor;

        void Start( ) {

            blood = GetComponent<Image>( );
            originalColor = blood.color;
            FadeEffect( );

        }

        public void FadeEffect( ) {
            StartCoroutine( FadeCoroutine( ) );
        }

        private IEnumerator FadeCoroutine( ) {

            // Get the start time and calculate the end time
            float startTime = Time.time;
            float endTime = startTime + fadeTime;

            // Fade the image over time
            while ( Time.time < endTime ) {

                // Calculate the current alpha value
                float timeSinceStart = Time.time - startTime;
                float alpha = Mathf.Lerp( 1f, 0f, timeSinceStart / fadeTime );

                // Set the new color of the image
                Color newColor = originalColor;
                newColor.a = alpha;
                blood.color = newColor;

                // Wait for the next frame
                yield return null;

            }

            // Set the final color of the image
            Color finalColor = originalColor;
            finalColor.a = 0f;
            blood.color = finalColor;

        }

    }

}