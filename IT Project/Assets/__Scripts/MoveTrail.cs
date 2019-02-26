using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour
{
    public int moveSpeed = 200;

    // Update is called once per frame
    void Update() {
        //Move an object over time instead of using a rigidBody - Time.deltaTime removes the effect of fps
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed); 
        Destroy(this.gameObject, 1);
    }
}
