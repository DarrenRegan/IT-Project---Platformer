using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public int health;
    private float dmgDelay = 1.5f;

    public Slider healthBar;
    public Animator anim;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 20) // enter stage 2
        {
            anim.SetTrigger("StageTwo");
        }

        if(health <= 10) // enter stage 3
        {
            anim.SetTrigger("StageThree");
        }

        if (health <= 0) // dies
        {
            anim.SetTrigger("Death");
        }

        // give the player time to recover before taking more damage
        if (dmgDelay > 0)
        {
            dmgDelay -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.GetComponent<Health>().Damaged();
        }
    }
}
