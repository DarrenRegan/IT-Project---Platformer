using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour{

    //Variables
    public int spawnDelay;

    //Creating a singleton so theres only access to a single instance of GM at one time
    public static GameMaster gm;

    //Transform for player respawning
    public Transform playerPrefab;
    public Transform spawnPoint = 2;
    

    void Start(){
        if (gm == null){
            //gm = this;
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public void RespawnPlayer(){
        //Maybe Add Effects or small sound effect
        yield return new WaitForSeconds(spawnDelay); //Adds a small delay for respawning
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        //Maybe add spawn effect if i have enough time
    }

    //Pass in Player type from class player
    public static void KillPlayer (Player player){
        Destroy(player.gameObject); //Kills player
    }



}
