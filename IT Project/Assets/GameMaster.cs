using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour{

    //Pass in Player type from class player
    public static void KillPlayer (Player player){
        Destroy(player.gameObject); //Kills player
    }
}
