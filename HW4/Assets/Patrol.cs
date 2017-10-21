using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    
    private Animator animator;
    public GameObject player;
    public Waypoint[] path;
    private MonoBehaviour currentBehavior;
    private StateHolder currentState;
    private Symbol threeHits;
    private Symbol threeSecs;
    private Symbol hit;
    private float threshold;
    private float timeToStopRunning;
    private int lives;
    public int currentWaypoint;

    void Start() {

        threeSecs = new Symbol("three seconds");
        threeHits = new Symbol("three hits");
        hit = new Symbol("hit");
        StateHolder dead = new StateHolder("dead");
        StateHolder runningAway = new StateHolder("running");
        StateHolder walking = new StateHolder("walking");
        walking.AddTransition(hit, runningAway);
        walking.AddTransition(threeHits, dead);
        runningAway.AddTransition(hit, runningAway);
        runningAway.AddTransition(threeHits, dead);
        runningAway.AddTransition(threeSecs, walking);
        this.currentState = walking;

        print(this.currentState.StateName);

        this.lives = 3;
        this.threshold = 1;
        this.animator = GetComponent<Animator>();

        this.timeToStopRunning = 0;
    }

    void Update() {

        if (this.currentState.StateName == "running") {
            if(Time.time > this.timeToStopRunning) {
                print("Stop run");
                animator.SetBool("Hit", false);
                this.currentState = this.currentState.ApplySymbol(this.threeSecs);
            }
            else {
                print("running");
                this.transform.rotation = Quaternion.Inverse(Quaternion.LookRotation(this.player.transform.position - this.transform.position));
                //this.transform.LookAt(-this.player.transform.position);
                this.transform.Translate(this.transform.forward * Time.deltaTime * 5, Space.World);
            }
        }
        if (this.currentState.StateName == "walking") {
            this.transform.LookAt(this.path[currentWaypoint].transform);
            this.transform.Translate(this.transform.forward * Time.deltaTime * 5, Space.World);

            float distance = Vector3.Distance(this.transform.position, this.path[currentWaypoint].transform.position);

            if (distance < this.threshold) {

                currentWaypoint++;
                currentWaypoint %= path.Length;
            }
        }
        
        
    }

    void OnTriggerEnter(Collider c) {
        if(c.transform.tag == "Bullet") {
            StateHolder prev = this.currentState;
            this.currentState = this.currentState.ApplySymbol(this.hit);
            print("Now in state " + this.currentState.StateName);
            this.timeToStopRunning = Time.time + 3f;
            this.lives--;
            animator.SetInteger("Lives", this.lives);
            animator.SetBool("Hit", true);
            if(lives == 0) {
                this.currentState = this.currentState.ApplySymbol(this.threeHits);
                animator.SetBool("Died", true);
                animator.SetBool("Hit", false);
                Destroy(this);
            }
        }
    }
}
