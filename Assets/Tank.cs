using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    Rigidbody rb;
    public float turnSpeed;
    public float moveSpeed;
    public GameObject shellPrefab;
    public GameObject shootPoint;
    public float shootSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Horizontal") * turnSpeed, 0);
        rb.AddForce(transform.forward * moveSpeed * Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown(0))
        {
            GameObject shell = GameObject.Instantiate(shellPrefab);
            shell.transform.position = shootPoint.transform.position;
            shell.GetComponent<Rigidbody>().velocity = shootPoint.transform.forward * shootSpeed;
        }
    }
}
