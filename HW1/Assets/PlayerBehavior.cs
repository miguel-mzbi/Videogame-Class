using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    private Vector3 _initialPosition;
    public int points;
    public GUIText scoreText;

	// Use this for initialization
	void Start () {
        this._initialPosition = this.transform.position;
        this.points = 0;
        this.UpdateScore();

    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        this.transform.Translate(h * 0.05f, 0f, v * 0.05f);
    }

    void OnCollisionEnter(Collision c) {
        if(c.transform.name == "Goal") {
            this.transform.position = this._initialPosition;
            this.points++;
        }
        else {
            this.transform.position = this._initialPosition;
            this.points--;
        }

        this.UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + this.points;
    }
}
