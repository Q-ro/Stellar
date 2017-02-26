using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {

    //Private variables
    //A reference to the rigid body of the object
    private Rigidbody2D _rigidBody2D;
    private Vector2 _moveDirection;
    private Animator _animator;

    //Public variables
    //Player's Health
    [Tooltip("Amount of hitpoint the player has")]
    public int health;
    //Player's movespeed
    [Tooltip("How fast the character goes")]
    public float moveSpeed;
    //Max speed the cahracter will have
    [Tooltip("Max speed for the player")]
    public float topSpeed;
    //Player's invincibility time
    [Tooltip("Recovery time")]
    public float invincibilityTime;

    //Flags
    //Keeps track of when the player is attacking
    public bool isAttack = false;
    //Keeps track of when the player is rolling
    public bool isRolling = false;
    //Keeps track of when the player is shooting
    public bool isShooting = false;
    //Keeps track of when the player is invincible
    public bool isInvinsible = false;
    //Keep track of wheter or not the player is moving
    public bool isMoving = false;

    // Use this for initialization
    void Start () {
        
        //store the reference to the current rigid body of this game object
        _rigidBody2D = this.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //Get the current input and generate a vector in the direction of the movement
        Vector2 _moveDirection = (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        // Make the player move in the direction of the vector
        _rigidBody2D.AddForce(_moveDirection + _rigidBody2D.position * Time.deltaTime);


        //Define the animation to play

        if (_animator != null)
        {
            if (_moveDirection != Vector2.zero)
            {
                _animator.SetBool("Iswalking", true);

                //TODO
                //Transfor into an angle, playe the wlaking animation that correcponds the best to the andle
                if (_moveDirection.x > 0)
                {
                }

                //_animator.SetFloat("Input_x", _rigidBody2D.x);
                //_animator.SetFloat("Input_y", _rigidBody2D.y);
            }
            else
            {
                _animator.SetBool("Iswalking", false);
            }
        }


    }

    string MoveDirection(Vector2 direction)
    {
        //Create an empty default vector for reference
        Vector2 defaultVector = new Vector2();

        //Get the current angle
        var angle = GetAngle(direction, defaultVector);

        if (angle > Mathf.PI / 4 && angle > Mathf.PI * 3 / 4)
        {
            return "UP";
        }
        if(angle >= Mathf.PI * 3/4 || angle <= -Mathf.PI * 3/4)
        {
            return "LEFT";
        }
        if (angle >= -Mathf.PI / 4 && angle <= Mathf.PI / 4)
        {
            return "RIGHT";
        }
        else
        {
            return "DOWN";
        }

        /*
        if (angle > Math.PI / 4 && angle < Math.PI * 3 / 4) return Directions.Up;
        else if (angle >= Math.PI * 3 / 4 || angle <= -Math.PI * 3 / 4) return Directions.Left;
        else if (angle >= -Math.PI / 4 && angle <= Math.PI / 4) return Directions.Right;
        else return Directions.Down;
        */
    }


    public float GetAngle(Vector2 pointA, Vector2 pointB)
    {
        var target = pointB - pointA;
        var angle = Vector2.Angle(pointA, pointB);
        var orientation = Mathf.Sign(pointA.x * target.y - pointA.y * target.x);
        return (360 - orientation * angle) % 360;
    }

}
