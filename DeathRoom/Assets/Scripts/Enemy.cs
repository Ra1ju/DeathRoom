using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public GameObject deathEffect;
    public float moveSpeed = 5f;
    public TextMeshProUGUI text;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("TMPro").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }


    private void MoveCharacter(Vector2 moveDirection)
    {
        rb.MovePosition((Vector2)transform.position + (moveDirection * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Player.points++;
            text.text = "POINTS: " + Player.points;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
