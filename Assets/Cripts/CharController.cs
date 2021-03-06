﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public float speed = 4f;

    Vector3 forward;
    Vector3 right;

            
	// Use this for initialization
	void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey)
        {
            Move();
        }
	}
    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"),  Input.GetAxis("VerticalKey"),0);
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
