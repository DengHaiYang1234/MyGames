using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody rig;
	// Use this for initialization
	void Start ()
	{
	    rig = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update ()
	{
        //局部坐标
	    rig.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
	}
}
