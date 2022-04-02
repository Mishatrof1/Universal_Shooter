using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public GameObject PlayerObject;
    public float Speed;
    public float MaxSpeed;
    public float SpeedUp;
    public float RatioBraking;
    public float PowerJump;
    public float PowerGravity;

    CharacterController PlayerControl;

    //bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl = GetComponent<CharacterController>();

        float InVertical = Input.GetAxis("Vertical");
        float InHorizontal = Input.GetAxis("Horizontal");
        float InJump = Input.GetAxis("Jump");
        float InSquat = Input.GetAxis("Squat");

        float PlayerHeight = PlayerControl.height;
        float PlayerHeightStand = PlayerHeight;
        float PlayerHeightSquat = PlayerHeight * 0.6f;

        float JumpSpeed = 0f;

        bool Jumped = false;

        if(InSquat != 0)
        {
            PlayerHeight = PlayerHeightSquat;
            PlayerObject.GetComponent<Transform>().localScale = new Vector3(1, PlayerHeightSquat, 1); // Для теста "приседаний"
        }
        else
        {
            PlayerHeight = PlayerHeightStand;
            PlayerObject.GetComponent<Transform>().localScale = new Vector3(1, PlayerHeightStand, 1); // Для теста "приседаний"
        }

        if((PlayerControl.isGrounded == true) && (InJump != 0))
        {
            Jumped = true;
            JumpSpeed = PowerJump;
        }

        if(Jumped == true)
        {
            if (JumpSpeed > 0)
            {
                JumpSpeed = JumpSpeed - (5 * Time.deltaTime);
            }
            else
            {
                Jumped = false;
            }
            
        }

        PlayerControl.Move(Vector3.up * JumpSpeed);

        PlayerControl.Move(Vector3.forward * InVertical * Speed);

        PlayerControl.Move(Vector3.right * InHorizontal * Speed/2);
    }

    void FixedUpdate()
    {
        PlayerControl.Move(Vector3.down);
    }
}
