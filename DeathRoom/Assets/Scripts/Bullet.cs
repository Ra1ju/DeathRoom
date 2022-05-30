using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody2D rb;
    private float timer = 0;
    private float limit = 1f;

    public float force;


    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force * 2;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= limit)
        {
            Destroy(gameObject);
        }
    }

}
