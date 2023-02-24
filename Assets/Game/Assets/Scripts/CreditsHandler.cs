using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


[ System.Serializable ]
public class Credit {

    public string title;
    public string source;


}


public class CreditsHandler : MonoBehaviour
{

    [ SerializeField ] public Credit[ ] creditsList;
    public float fadeDuration = 1f;
    public float displayTextDuration = 1.5f;     
    public float timeDuration;

    public bool completed = false;

    public int currentIndex = 0;

    float m_Timer;


    public TextMeshProUGUI titleText;
    public TextMeshProUGUI sourceText;

    void goToMenu( ) {

        SceneManager.LoadScene( "Menu" );

    }
    void setText( Credit currentElement ) {

        titleText.text = currentElement.title;
        sourceText.text = currentElement.source;

    }

    // Start is called before the first frame update
    void Start()
    {
        setText( creditsList[ currentIndex ] );

    }

    // Update is called once per frame
    void Update()
    {
        
        if ( Input.GetKeyDown( "escape" ) || Input.GetKeyDown( "space" ) ) {
            
            if ( !completed ) {
                
                completed = true;

                goToMenu( );
                
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
                    setText( creditsList[ currentIndex ] );

                } else {

                    completed = true;
                    titleText.alpha = 1;
                    sourceText.alpha = 1;

                    goToMenu( );

                }

            }
        
        }
    }
}
