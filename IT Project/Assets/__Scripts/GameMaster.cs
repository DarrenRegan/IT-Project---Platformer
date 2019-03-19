using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour{

    //Variables
    public int spawnDelay = 2;

    //Creating a singleton so theres only access to a single instance of GM at one time
    public static GameMaster gm;

    //Transform for player respawning
    public Transform playerPrefab;
    public Transform spawnPoint;
    

    void Start(){
        if (gm == null){
            //gm = this;
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    //https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?redirectedfrom=MSDN&view=netframework-4.7.2
    //Coroutines & IEnumerator - Stops a function from executing until a condition is met, and then continues where it left off
    //So IEnumerator will use WaitforSeconds(spawnDelay) as its condition when its met it will spawn the player
    public IEnumerator RespawnPlayer(){
        //Maybe Add Effects or small sound effect
        yield return new WaitForSeconds(spawnDelay); //Adds a small delay for respawning
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        //Maybe add spawn effect if i have enough time
    }

    //Pass in Player type from class player
    public static void KillPlayer (Player player){
        Destroy(player.gameObject); //Kills player
        gm.StartCoroutine(gm.RespawnPlayer());
    }



}
