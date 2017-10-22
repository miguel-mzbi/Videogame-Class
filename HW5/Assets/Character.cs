using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private bool runningCorroutine;
    public Waypoint[] defaultPath;
    private int current;

    // Use this for initialization
    void Start () {

        this.current = 0;
        this.runningCorroutine = false;

	}
	
	// Update is called once per frame
	void Update () {
        if(this.runningCorroutine == false) {

            print("DOING DEFAULT PATH");
            this.transform.LookAt(this.defaultPath[this.current].transform);
            this.transform.Translate(this.transform.forward * Time.deltaTime * 2f, Space.World);

            if (Vector3.Distance(this.transform.position, this.defaultPath[this.current].transform.position) < 0.5f) {

                this.current++;
                this.current %= defaultPath.Length;

            }
        }
	}

    private void OnMouseDown() {

        GameObject startWP = this.FindClosestWaypoint();
        Waypoint startWPScript = startWP.GetComponent<Waypoint>();
        List<Waypoint> path = BreathWise.BFSearch(startWPScript);
        StopAllCoroutines();
        this.runningCorroutine = true;
        StartCoroutine(this.MoveInGraph(path));

    }

    private GameObject FindClosestWaypoint() {

        GameObject[] wps;
        wps = GameObject.FindGameObjectsWithTag("Waypoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 playerPosition = this.transform.position;
        
        foreach (GameObject wp in wps) {
            
            float dTemp = Vector3.Distance(wp.transform.position, playerPosition);
            if (dTemp < distance) {

                closest = wp;
                distance = dTemp;

            }
        }
        print("The closests is : " + closest.transform.name);
        return closest;

    }

    private IEnumerator MoveInGraph(List<Waypoint> path) {

        float threshold = 0.5f;

        foreach(Waypoint nextWP in path) {
            while(threshold < Vector3.Distance(this.transform.position, nextWP.transform.position)) {

                print("DOING BF FROM START: " + path[0].transform.name);
                this.transform.LookAt(nextWP.transform);
                this.transform.Translate(this.transform.forward * Time.deltaTime * 4f, Space.World);
                yield return null;

            }
        }

        string currentName = path[path.Count - 1].transform.name;
        int.TryParse(currentName.Substring(10), out this.current);
        this.runningCorroutine = false;
        yield break;

    }
}
