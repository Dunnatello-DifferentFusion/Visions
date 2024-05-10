using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using Visions.Player;
using UnityEngine.UI;

public class AI : MonoBehaviour {

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    private GameObject player;
    private Health playerHealthScript;

    //Zombie Stats
    [SerializeField] private float health = 100f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float attackDelay = 1.0f;

    [SerializeField] private GameObject healthUI;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float updateHealthSpeed = 5f;

    private float delayRemaining;
    private float damageMultiplier;

    private void Start( ) {

        delayRemaining = attackDelay;

        player = GameObject.FindGameObjectWithTag( "Player" );
        playerHealthScript = player.GetComponent<Health>( );

        agent.SetDestination( player.transform.position );


        //Randomize Movement Speed and Damage Multiplier
        agent.speed = Random.Range( 3.0f, 6.0f );
        damageMultiplier = Random.Range( 0.6f, 1.5f );

        healthSlider.value = health / maxHealth;
        healthUI.SetActive( false );
    }

    public void TakeDamage( int damage ) {
        
        health -= damage;
        UpdateUI( );

    }

    public void UpdateUI( ) {

        if ( !healthUI.activeInHierarchy )
            healthUI.SetActive( true );

        StartCoroutine( TransitionHealth( ) );

    }

    private IEnumerator TransitionHealth( ) {

        float visualHealth = healthSlider.value;
        float targetHealth = health / maxHealth;

        while ( healthSlider.value != targetHealth ) {

            visualHealth -= Time.deltaTime * updateHealthSpeed;

            if ( visualHealth < targetHealth ) {
                
                visualHealth = targetHealth;
            }

            healthSlider.value = visualHealth;

            yield return null;

        } 

    }

    private void Update( ) {

        // Zombie Not In Range
        if ( Vector3.Distance( this.transform.position, player.transform.position ) > 2.0f ) {
            agent.isStopped = false;
            animator.SetBool( "isMoving", true );
            agent.SetDestination( player.transform.position );
        }
        else {

            // Zombie Attacks Player
            if ( delayRemaining <= 0 ) {
                playerHealthScript.TakeDamage( Random.Range( 8, 11 ) * damageMultiplier );
                delayRemaining = attackDelay;
            }

            animator.SetBool( "isMoving", false );
            agent.isStopped = true;

        }

        if ( delayRemaining >= 0 ) {
            delayRemaining -= Time.deltaTime;
        }
        
        // Zombie Dies
        if ( health <= 0 ) {
            Destroy( gameObject );
        }

    }

}
