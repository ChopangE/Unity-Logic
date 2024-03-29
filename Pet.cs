using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public Transform playerPos;
    public SpriteRenderer player;
    public float speed;
    float timer;
    SpriteRenderer sprite;
    void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector3 dir = new Vector3(0, 1.5f, 0);
        dir.x = player.flipX ? 1.5f : -1.5f;
        sprite.flipX = !player.flipX;
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position + dir , 3f * Time.deltaTime);
        
    }

    
}
