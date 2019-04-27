using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float moveSpeed = 6f;
    int damage = 1;

    Rigidbody2D rb;

    Player target;
    Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        // subtract bullet position from player position to get target
        direction = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(direction.x, direction.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = new Player();

        if (collision.gameObject.name.Equals("Player"))
        {
            player.DamagePlayer(damage);
            Destroy(gameObject);
        }
    }
}
