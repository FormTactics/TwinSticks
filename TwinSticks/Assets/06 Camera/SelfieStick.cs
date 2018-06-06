using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

    public float panSpeed = 5f;

    private GameObject Player;

    // Get initial rotation settings
    private Vector3 armRotation;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

        armRotation.x += Input.GetAxis("RVert") * panSpeed;
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
		transform.position = Player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
	}

}
