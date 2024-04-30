namespace Visions.Environment {
    using UnityEngine;

    public class WaterRollingTexture : MonoBehaviour {

        private Renderer waterMat;

        private float currentOffset = 0;
        [SerializeField] private float speed = 1;

        // Start is called before the first frame update
        void Start( ) {

            waterMat = gameObject.GetComponent<Renderer>( );

        }

        // Update is called once per frame
        void Update( ) {

            currentOffset += ( Time.deltaTime * speed );

            if ( currentOffset > 1 ) {

                currentOffset = 0;

            }

            waterMat.material.SetTextureOffset( "_MainTex", new Vector2( 0, currentOffset ) );

        }

    }

}