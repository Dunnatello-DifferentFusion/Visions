namespace Visions.LevelManagement {

    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    using System.Threading.Tasks;


    public class LevelManager : MonoBehaviour {
        // Start is called before the first frame update

        public static LevelManager Instance;

        [SerializeField] private GameObject loaderCanvas;
        [SerializeField] private Image progressBar;
        private float target = 0f;

        void Awake( ) {

            if ( Instance == null ) {

                Instance = this;
                DontDestroyOnLoad( gameObject );

            }
            else {

                Destroy( gameObject );

            }

        }

        public async void LoadScene( string sceneName ) {

            progressBar.fillAmount = 0f;

            var scene = SceneManager.LoadSceneAsync( sceneName );
            scene.allowSceneActivation = false;

            loaderCanvas.SetActive( true );

            do {

                target = scene.progress;
                await Task.Delay( 1 );

            } while ( scene.progress < 0.9f );

            scene.allowSceneActivation = true;

            loaderCanvas.SetActive( false );

        }

        // Update is called once per frame
        private void Update( ) {

            progressBar.fillAmount = Mathf.MoveTowards( progressBar.fillAmount, target, 3 * Time.deltaTime );

        }
    }

}