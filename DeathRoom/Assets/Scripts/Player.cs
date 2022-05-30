using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float x;
    private float y;

    public static int points = 0;

    [SerializeField]
    private float moveSpeed = 10;

    private void Start()
    {
        points = 0;
    }
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(x, y, 0) * Time.deltaTime * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}
