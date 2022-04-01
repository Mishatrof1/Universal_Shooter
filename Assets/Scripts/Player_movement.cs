using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public GameObject PlayerObject;
    public Vector3 PlayerPos;
    public float Speed;
    public float MaxSpeed;
    public float SpeedUp;

    float InputVertical = Input.GetAxis("Vertical");
    float InputHorizontal = Input.GetAxis("Horizontal");
    float InputJump = Input.GetAxis("Jump");


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // кек
    }
}
