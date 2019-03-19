using UnityEngine;
using Pathfinding; //Import A * Pathfinding

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class enemyAI : MonoBehaviour{

    public Transform target;

    //Update Rate for updating path
    public float updateRate = 2f;

    //Caching
    private Seeker seeker;
    private Rigidbody2D rigidbody;

    //The Calc Path
    public Path path;

    //AI Speed per second
    public float speed = 300f;
    public ForceMod2D fMode; //ForceMod changes between force and impulse

    [HideInInspector] //Public but won't show in Inspector
    public bool pathIsEnded = false;

    //Max DIstance from AI to waypoint for it to continue to next waypoint
    public float nextWayPointDistance = 3;




}
