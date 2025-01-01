using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private Rigidbody myBody;
	private Animator anim;

	private bool isPlayerMoving;
	private float playerSpeed = 0.5f;

	private float rotationSpeed = 4f;
	private float jumpForce = 3f;

	private bool canJump;
	private float moveHorizontal, moveVertical;

	private float rotY = 0f;

	public Transform groudCheck;
	public LayerMask groundLayer;

	void Awake()
    {
		myBody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
    }

	void Start () {
		rotY = transform.localRotation.eulerAngles.y;

	}
	
	void Update () {
		PlayerMoveKeyboard();
		AnimatePlayer();
		Attack();
		IsOnGround();
		Jump();
	}

	void FixedUpdate()
    {
		MoveAndRotate();
    }

	void PlayerMoveKeyboard()
	{
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			moveHorizontal = -1f;
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
			moveHorizontal = 0;
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			moveHorizontal = 1f;
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
			moveHorizontal = 0;
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			moveVertical = 1f;
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
			moveVertical = 0;


	}

	void MoveAndRotate()
    {
		if (moveVertical != 0)
			myBody.MovePosition(transform.position + transform.forward * moveVertical * playerSpeed);

		rotY += moveHorizontal * rotationSpeed;
		myBody.rotation = Quaternion.Euler(0f, rotY, 0f);
    }

	void AnimatePlayer()
    {
		if (moveVertical !=0)
        {
			if (!isPlayerMoving)
            {
				if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
					isPlayerMoving = true;
					anim.SetTrigger(MyTags.RUN_TRIGGER);
                }
            }
        }
        else
        {
			if(isPlayerMoving)
            {
				if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
					isPlayerMoving = false;
					anim.SetTrigger(MyTags.STOP_TRIGGER);
                }

			}
		}
    }

	void Attack()
    {
		if (Input.GetKeyDown(KeyCode.K))
        {
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION) ||
				!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ATTACK_ANIMATION))
            {
				anim.SetTrigger(MyTags.ATTACK_TRIGGER);
            }
        }
    }

	void IsOnGround()
    {
		canJump = Physics.Raycast(groudCheck.position, Vector3.down, 0.1f, groundLayer);

    }

	void Jump()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
			if (canJump)
            {
				canJump = false;
				myBody.MovePosition(transform.position + transform.up * jumpForce * playerSpeed);
				anim.SetTrigger(MyTags.JUMP_TRIGGER);
            }
        }
    }
}
