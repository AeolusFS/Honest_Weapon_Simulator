﻿using System.Collections;
using UnityEngine;

public class player : MonoBehaviour {
    public float moveSpeed;
    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    public gun theGun;
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlan = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if(groundPlan.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y,pointToLook.z));
        }
        if (Input.GetMouseButtonDown(0))
            theGun.isFiring = true;
        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;
		
	}
    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}