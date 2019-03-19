using UnityEngine;
using Pathfinding; //Import A * Pathfinding
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class enemyAI : MonoBehaviour{

    //Target to chase
    public Transform target;

    //Update Rate for updating path
    public float updateRate = 2f;

    //Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //The Calc Path
    public Path path;

    //AI Speed per second
    public float speed = 300f;
    public ForceMode2D fMode; //ForceMod changes between force and impulse

    [HideInInspector] //Public but won't show in Inspector
    public bool pathIsEnded = false;

    //Max DIstance from AI to waypoint for it to continue to next waypoint
    public float nextWayPointDistance = 3;
    //Waypoint Moving towards
    private int currentWaypoint = 0;

    void Start(){
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null){
            Debug.LogError("No Player Found");
            return;
        }

        //Starts path to target pos and return result to OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        //IEnumerator Function
        StartCoroutine (UpdatePath ());

    }

    IEnumerator UpdatePath(){
        if (target == null){
            //add player search
            yield return false;
        }
        
        //Starts path to target pos and return result to OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds ( 1f/updateRate);
        StartCoroutine (UpdatePath());
    }

    public void OnPathComplete (Path p){
        Debug.Log("Path error " + p.error);
        if (!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    //Like update but updates on fixed update rate
    void FixedUpdate () {
        
        if (target == null){
            //add player search
            return;
        }

        //Enemies could look at player

        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count){
            if (pathIsEnded)
                return;
            Debug.Log("End of Path Reached");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to waypoint - returns currencyWaypoint - current position
        //.Normalized - Vector will have a total length of 1
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //Move AI
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWayPointDistance){
            currentWaypoint++;
            return;
        }

    }
}
