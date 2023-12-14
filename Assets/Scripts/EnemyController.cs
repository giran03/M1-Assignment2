using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 direction;
    Rigidbody enemy_rb;
    Renderer rend;
    int random_behaviour;
    float movementSpeed;
    bool isMoving;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.cyan);
        enemy_rb = GetComponent<Rigidbody>();
        isMoving = true;
        movementSpeed = 5f;
    }

    void Update()
    {
        MoveEnemy();
        random_behaviour = Random.Range(1, 4);
    }

    private void MoveEnemy()
    {
        if (!isMoving) return;
        GameObject cannon = GameObject.FindGameObjectWithTag("Cannon");
        direction = (cannon.transform.position - transform.position).normalized;
        transform.Translate(movementSpeed * Time.deltaTime * direction);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            if (random_behaviour == 1)
            {
                isMoving = false;
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else if (random_behaviour == 2)
            {
                isMoving = false;
                rend.material.SetColor("_Color", Color.green);
                enemy_rb.AddForce(Vector3.up * 25f, ForceMode.Impulse);
                Destroy(gameObject, 2.5f);
                Destroy(other.gameObject);
            }
            else if (random_behaviour == 3)
            {
                movementSpeed *= 2f;
                rend.material.SetColor("_Color", Color.red);
                transform.localScale = transform.localScale * 1.5f;
                Vector3 increaseY = new(transform.position.x, transform.position.y + .5f, transform.position.z);
                transform.position = increaseY;
                Destroy(other.gameObject);
            }
        }
    }
}
