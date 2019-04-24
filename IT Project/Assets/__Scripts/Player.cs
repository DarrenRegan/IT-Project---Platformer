using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]
    public class PlayerStats {
        public int Health = 3;
    }

    public PlayerStats playerStats = new PlayerStats();
    public int fallBoundary = -15;

    void Update() { //If PLayer falls below y -15 player will instantly die
        if(transform.position.y <= fallBoundary)
            DamagePlayer(999);
    }

    public void DamagePlayer (int damage){

        playerStats.Health -= damage;

        if (playerStats.Health <= 0){
            Debug.Log("Kill Player HP = 0");
            GameMaster.KillPlayer(this); //Kills current instance of player
        }
    }
}
