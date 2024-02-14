using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    Rigidbody2D rb;
    public Player player;
    float timer = 0f;
    bool isShoot = false;
    bool isComing = false;
    Vector2 pp;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Vector2 curVec = player.inputVec.normalized;
        if (isShoot) {
            timer += Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && !isShoot && !isComing) {
            pp = curVec;
            rb.AddForce(pp * 5f, ForceMode2D.Impulse);
            isShoot = true;
            
        }

        if (timer >= 0.5f && isShoot) {
            rb.AddForce(-pp * 3f, ForceMode2D.Impulse);
            timer = 0f;
        }

        if(rb.velocity.magnitude <= 0.3f && isShoot) {
            isComing = true;
            isShoot = false;
            rb.velocity = Vector2.zero;
        }

        if (isComing) {
            Vector3 dir = player.transform.position - transform.position;
            dir = dir.normalized;
            rb.MovePosition(transform.position + dir * Time.fixedDeltaTime * 8f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;
        gameObject.SetActive(false);
    }
    void OnEnable() {
        isShoot = false;
        isComing = false;
    }
}
