using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {

    //A reference to the rigid body of the object
    private Rigidbody2D _rigidBody2D;
    private Vector2 _velocity;
    [Tooltip("Amount of hitpoint the player has")]
    public int health;
    [Tooltip("How fast the character goes")]
    public float moveSpeed;
    [Tooltip("Recovery time")]
    public float invincibilityTime;

    //Flags
    public bool isAttack = false;
    public bool isRolling = false;
    public bool isShooting = false;
    public bool isInvinsible = false;



    // Use this for initialization
    void Start () {
        
        //store the reference to the current rigid body of this game object
        _rigidBody2D = this.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //Check for key presses
        if(Input.GetButtonDown("UP"))
        {

        }
        if (Input.GetButtonDown("DOWN"))
        {

        }

        if (Input.GetButtonDown("LEFT"))
        {

        }

        if (Input.GetButtonDown("RIGHT"))
        {

        }

        if (Input.GetButtonDown("Fire1"))
        {

        }

    }

}
