using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    //Weapon Variables
    public float fireRate = 0; //Public to edit it - Hold down button to fire and single burst shooting
    public int dmg = 1; //Damage of shooting
    public LayerMask whatToHit; //Tell unity what we want to hit --- List of all layers, can use unity to decide what layers you dont want to hit

    //Prefabs
    public Transform BulletTrailPrefab;
    public Transform shootEffectPrefab;

    float effectSpawnRate = 10;
    float timeToSpawnEffect = 0;

    float timeToFire = 0;
    Transform firePoint; //Stores firePoint




    // Awake is called before the first frame update
    void Awake(){
        firePoint = transform.Find("FirePoint"); //Finds Child of Parent Shotter, called PointOfFire, instead of calling a GameObject which will call everything
        if (firePoint == null){
            Debug.LogError("No FirePoint Found!");// Debug msg if no firePoint found
        }
    }

    //Used to handle fire rates
    void Update(){
       // Shoot(); //Shoots forever for testing purposes
        if (fireRate == 0){ //Single Burst
            if (Input.GetButtonDown ("Fire1")) { //Button down Shoot
                Shoot();
            }
        }
        else {
            if (Input.GetButton ("Fire1") && Time.time > timeToFire) { //Hold down shoot - timeToFire is a delay, so when Time.time is > then timeToFire you can shoot
                timeToFire = Time.time + 1 / fireRate; //Determines time of each shot
                Shoot();
            }
        }
    }//Update()

    //Raycasting
    void Shoot(){
        //Debug.Log("Test for shooting"); //Test fireRate
        //Create Vector2 and assign it mouse positions for x and y
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y); //Stores position of shooting position
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit); //mousePos - firePointPos finds the point of fire

        if(Time.time >= timeToSpawnEffect){
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }

        //Turn on Gizmos to see Drawn Line
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.red); //Makes line very long
        if(hit.collider != null){
            Debug.DrawLine(firePointPosition, hit.point, Color.yellow);
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if(enemy != null){
                enemy.DamageEnemy(dmg);
                Debug.Log("Hit: " + hit.collider.name + "  with " + dmg + "damage!");
            }
        }
    }

    //Shooting effect
    //Creates instance of object prefabs with position and rotation
    //Instantiate clones the object and returns a clone - Parameters (Original, position, rotation, parent, instanceiateWorldSpace)
    void Effect(){
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
       Transform clone = Instantiate(shootEffectPrefab, firePoint.position, firePoint.rotation) as Transform; //(Transform) casts instantiate as a transform object
       clone.parent = firePoint;

       float size = Random.Range (0.6f, 0.9f);

       clone.localScale = new Vector3 (size, size, size); // new Vector3(x,y,z)
       Destroy(clone.gameObject, 0.05f); //Destroys object after 0.05f
    }


}//end
