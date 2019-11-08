using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_TwoHalfDController_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 08/08/2019
    /// Control script for a side scroller. Tailored for 2.5d play.
    /// </summary>

    [System.Serializable]
    public class ControlSettings 
    {
        public float movementSpeed = 5.0f;
        public float jumpHeight = 5.0f;
        public float groundDetectionRange = 0.55f;
        public float gravityMultiplier = 10f;
        public LayerMask platformDetection;
    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string VERTICAL_AXIS = "Vertical"; //^v
        public string HORIZONTAL_AXIS = "Horizontal"; //<>
        public string JUMP_AXIS = "Jump"; //_

        public float verticalInput;
        public float horizontalInput;
        public float jumpInput;
    }

    [System.Serializable]
    public class PlayerData
    {
        public GameObject player;
        public Rigidbody playerRB;
        public Collider playerCollider;
        public Animator playeranim;

    }

    [System.Serializable]
    public class Cheats
    {
        public bool ignoreDeath = false; //ignore destroy colliders
        public bool inclementWeather = false; //give all weather abilities
        public bool invisibleUsagi = false; //undetectable by enemies
        public bool flyingUsagi = false; //no jump limiting
        public bool ghostUsagi = false; //go through walls
    }

    public ControlSettings controlSetting = new ControlSettings();
    public InputSettings inputSetting = new InputSettings();
    public PlayerData playerData = new PlayerData();
    public Cheats cheat = new Cheats();

    public void Start()
    {
        Get();

    }

    public void FixedUpdate()
    {
        GetInput();
        Movement();
        Jump();
        Cheat();

    }

    public bool CanJump() //Jump range detection
    { 
        if(cheat.flyingUsagi == true)
        {
            return false;
        }
        else
        {
            RaycastHit ground;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out ground, controlSetting.groundDetectionRange, controlSetting.platformDetection))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * ground.distance, Color.yellow);
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1, Color.green);
                return false;
            }
        }
    }

    public void Get()
    {
        playerData.player = GameObject.FindWithTag("Player");
        playerData.playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        playerData.playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider>();
        playerData.playeranim = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
    }

    public void GetInput()
    {
        inputSetting.verticalInput = Input.GetAxis(inputSetting.VERTICAL_AXIS);
        inputSetting.horizontalInput = Input.GetAxis(inputSetting.HORIZONTAL_AXIS);
        inputSetting.jumpInput = Input.GetAxis(inputSetting.JUMP_AXIS);
    }

    public void Movement()
    {
        if (Mathf.Abs(inputSetting.horizontalInput) > inputSetting.inputDelay)
        {
            
            //Move Player
            playerData.player.transform.position +=
                (Vector3.right
                * Time.deltaTime
                * inputSetting.horizontalInput
                * controlSetting.movementSpeed);

            //anim
            playerData.playeranim.SetBool("IsHopping", true);
            playerData.playeranim.SetBool("IsIdle", false);

            if(inputSetting.horizontalInput < 0)
            {
                playerData.player.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if(inputSetting.horizontalInput > 0)
            {
                playerData.player.transform.localScale = new Vector3(1f, 1f, 1f);
            }

        }
        else
        {
            playerData.playeranim.SetBool("IsIdle", true);
            playerData.playeranim.SetBool("IsHopping", false);
        }
    }

    public void Jump()
    {
        CanJump();
        if (CanJump() == false)
        {
            playerData.playeranim.SetBool("IsJumping", true);
            playerData.playerRB.AddForce(0, -controlSetting.gravityMultiplier * Time.deltaTime, 0, ForceMode.Impulse);
        }
        else
        {
            if(inputSetting.jumpInput > 0)
            {playerData.playeranim.SetBool("IsJumping", true);}
            else
            {playerData.playeranim.SetBool("IsJumping", false);}
            
        }

        if (CanJump() == true && inputSetting.jumpInput > 0)
        {
            playerData.playerRB.velocity += inputSetting.jumpInput * controlSetting.jumpHeight * Vector3.up;
            //playerData.playerRB.AddForce(0, inputSetting.jumpInput * controlSetting.jumpHeight, 0, ForceMode.Impulse);  
        }

    }
    public void Cheat()
    {
        float gravMultiplier_Temp = controlSetting.gravityMultiplier;


        if (cheat.flyingUsagi == true)
        {
            playerData.playerRB.useGravity = !cheat.flyingUsagi;
            controlSetting.gravityMultiplier = 0;

            //Fly Player
            if(inputSetting.verticalInput != 0)
            {
                playerData.player.transform.position += 
               (Vector3.up
               *Time.deltaTime
               * inputSetting.verticalInput
               * controlSetting.movementSpeed); ;
            }
        }
        else if(cheat.flyingUsagi == false)
        {
            playerData.playerRB.useGravity = !cheat.flyingUsagi;
            controlSetting.gravityMultiplier = gravMultiplier_Temp;
        }
    }
}
