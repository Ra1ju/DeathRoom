using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;

    public GameObject bullet;
    public Transform firePointTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

   
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }


        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, firePointTransform.position, Quaternion.identity);
        }
    }
}
