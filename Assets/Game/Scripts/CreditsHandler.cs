namespace Visions.UI {

    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;


    [System.Serializable]
    public class Credit {

        public string title;
        public string source;

    }

    public class CreditsHandler : MonoBehaviour {

        [SerializeField] private Credit[ ] creditsList;
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private float displayTextDuration = 1.5f;
        [SerializeField] private float timeDuration;

        private bool completed = false;
        private int currentIndex = 0;

        private float m_Timer;

        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI sourceText;

        void GoToMenu( ) {

            SceneManager.LoadScene( "Menu" );

        }
        void SetText( Credit currentElement ) {

            titleText.text = currentElement.title;
            sourceText.text = currentElement.source;

        }

        // Start is called before the first frame update
        void Start( ) {
            SetText( creditsList[ currentIndex ] );

        }

        // Update is called once per frame
        void Update( ) {

            if ( Input.GetKeyDown( KeyCode.Escape ) || Input.GetKeyDown( KeyCode.Space ) ) {

                if ( !completed ) {

                    completed = true;

                    GoToMenu( );

                }

            }

            m_Timer += Time.deltaTime;

            if ( !completed ) {

                titleText.alpha = m_Timer / fadeDuration;
                sourceText.alpha = m_Timer / fadeDuration;

                if ( m_Timer > fadeDuration + displayTextDuration ) {

                    titleText.alpha = 0;
                    sourceText.alpha = 0;
                    m_Timer = 0;

                    if ( currentIndex < creditsList.Length - 1 ) {

                        currentIndex++;
                        SetText( creditsList[ currentIndex ] );

                    }
                    else {

                        completed = true;
                        titleText.alpha = 1;
                        sourceText.alpha = 1;

                        GoToMenu( );

                    }

                }

            }

        }

    }

}