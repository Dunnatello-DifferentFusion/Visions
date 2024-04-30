using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Visions.Player;

public class AI : MonoBehaviour {

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    private GameObject player;
    private Health playerHealthScript;

    //Zombie Stats
    [SerializeField] private int health = 100;
    [SerializeField] private float attackDelay = 1.0f;

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
    }

    public void TakeDamage( int damage ) {
        health -= damage;
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
            this.gameObject.SetActive( false );
        }

    }

}
