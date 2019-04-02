using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats {
        //Variables
        private int _curHealth;
        public int maxHealth = 100;

        public int curHealth{
            get { return _curHealth; } //Returns private variable _curHealth
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); } //Clamps HP between 0 and maxHealth to prevent negative HP values
        }
    
        public void Init(){
            curHealth = maxHealth; //Set hp at start of game
        }
    }

    public EnemyStats enemyStats = new EnemyStats();

    [Header("Optional: ")]
    [SerializeField]
    private Status status;

    void Start(){
        enemyStats.Init();

        if(status != null){
            status.SetHealth(enemyStats.curHealth, enemyStats.maxHealth);
        }
    }

    public void DamageEnemy (int damage){

        enemyStats.curHealth -= damage;

        if (enemyStats.curHealth <= 0){
            Debug.Log("Kill Player HP = 0");
            GameMaster.KillEnemy(this); //Kills current instance of enemy
        }

        if(status != null){
            status.SetHealth(enemyStats.curHealth, enemyStats.maxHealth);
        }

    }
}
