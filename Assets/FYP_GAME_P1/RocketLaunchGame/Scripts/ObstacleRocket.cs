using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRocket : MonoBehaviour
{
    public Vector3 moveDir;         // direction to move in
    public float moveSpeed;         // speed to move at along moveDir

    private float aliveTime = 15.0f; // time before object is destroyed

    void Start ()
    {
        Destroy(gameObject, aliveTime);
    }

    void Update ()
    {
        // move obstacle in certain direction over time
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        // rotate obstacle
        transform.Rotate(Vector3.back * moveDir.x * (moveSpeed * 20) * Time.deltaTime);

        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        GameManagerRocket.health -= 1;
    }


}