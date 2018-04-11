using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCharController : MonoBehaviour {
    public float speed;
    float speedX;
    float speedY;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -speed;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            speedX = speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            speedY = -speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speedY = speed;
        }
        transform.Translate(speedX, speedY, 0); //Транслейт чек
        speedX = 0;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
