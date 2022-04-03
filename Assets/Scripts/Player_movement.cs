using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public GameObject PlayerObject;
    public float Speed;
    public float MaxSpeed;
    public float SpeedUp;
    public float RatioSprintSpeed;
    public float RatioBraking;
    public float PowerJump;
    public float PowerGravity;
    public float Sensitivity;

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
        float InSquat = Input.GetAxis("Squat");
        float InSprint = Input.GetAxis("Sprint");

        bool SprintingMod = false;

        float PlayerHeight = 1;
        float PlayerHeightStand = PlayerHeight;
        float PlayerHeightSquat = PlayerHeight * 0.6f;

        PlayerControl.transform.Rotate(0, Input.GetAxis("Mouse X") * Sensitivity, 0);

        if (InSquat != 0)
        {
            PlayerObject.GetComponent<CharacterController>().height = PlayerHeightSquat; // Для теста "приседаний"
        }
        else
        {
            PlayerObject.GetComponent<CharacterController>().height = PlayerHeightStand; // Для теста "приседаний"
        }

        if (InVertical > 0)
        {
            if (SpeedUp < 1)
            {
                SpeedUp = SpeedUp + 0.1f;
            }
            else
            {
                SpeedUp = 1f;
            }
        }
        else if ((InVertical < 0) && (SpeedUp < 0.3f))
        {
            if (SpeedUp > -0.5f)
            {
                SpeedUp = SpeedUp - 0.05f;
            }
            else
            {
                SpeedUp = -0.5f;
            }
        }
        else
        {
            if(SpeedUp > 0)
            {
                SpeedUp = SpeedUp - RatioBraking;
            }
            else
            {
                SpeedUp = 0;
            }
        }

        if (InSprint == 0)
        {
            SprintingMod = false;
        }
        else
        {
            SprintingMod = true;
        }


        if (SprintingMod == false)
        {
            PlayerControl.Move(transform.forward * SpeedUp * Speed);
        }
        else
        {
            PlayerControl.Move(transform.forward * SpeedUp * Speed * RatioSprintSpeed);
        }

        PlayerControl.Move(transform.right * InHorizontal * Speed/2);
    }

    

    void FixedUpdate()
    {
        float JumpSpeed = 0f;

        bool Jumped = false;

        float InJump = Input.GetAxis("Jump");

        PlayerControl.Move(Vector3.down/10);

        if ((PlayerControl.isGrounded == true) && (InJump != 0) && (Jumped == false))
        {
            Jumped = true;
            JumpSpeed = PowerJump;
        }

        if (Jumped == true)
        {
            if (JumpSpeed > 0)
            {
                PlayerControl.Move(Vector3.up * JumpSpeed);
                JumpSpeed = JumpSpeed - 0.1f;
            }
            else
            {
                Jumped = false;
                JumpSpeed = 0;
            }
        }
    }
}
