using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public int playerId = 0;

    private Rigidbody2D myBody;
    private Player player;

    public float moveSpeedDefault;
    private float moveSpeed = 0;
    public float dashMultiplier = 1.5f;

    public GameObject rightHand;
    public GameObject rightHandSword;
    public GameObject topHand;
    public GameObject bottomHand;

    public float slashSmoothspeed = 0.0125f;

    private bool isMovingUp;
    private bool isMovingRight;

    // Start is called before the first frame update

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        moveSpeed = moveSpeedDefault;
    }


    private void Update()
    {
        if (player.GetButtonDown("Dash"))
        {
            moveSpeed = moveSpeed * dashMultiplier;

            Debug.Log("DashSpeed");
        }
        if (player.GetButtonUp("Dash"))
        {
            moveSpeed = moveSpeedDefault;
            Debug.Log("NormalSpeed");
        }

        
        // LightSlash(new Vector2(rightHand.transform.position.x, rightHand.transform.position.y));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = player.GetAxis("Horizontal Move");

        float verticalMove = player.GetAxis("Vertical Move");


        if (horizontalMove > 0.0)
        {
        
            this.transform.position += (Vector3.right * Time.deltaTime) * moveSpeed;
            this.transform.localScale = new Vector3(1, 1, 1);
            rightHand.SetActive(true);
           
        }
        else if (horizontalMove < 0.0)
        {
         
            this.transform.position -= (Vector3.right * Time.deltaTime) * moveSpeed;
            this.transform.localScale = new Vector3(-1, 1, 1);
            rightHand.SetActive(true);
            
        }

        if (verticalMove > 0.0)
        {
        
            this.transform.position += (Vector3.up * Time.deltaTime) * moveSpeed;
            topHand.SetActive(true);
            bottomHand.SetActive(false);
           
        }
        else if (verticalMove < 0.0)
        {
  
            this.transform.position -= (Vector3.up * Time.deltaTime) * moveSpeed;
            bottomHand.SetActive(true);
            topHand.SetActive(false);
            
        }
     

       



        if (player.GetButtonDown("Light Attack"))
        {
            //checking attack direction based off direction of stick held
       
        }


    }

    private void LightSlash(Vector2 start)
    {
    
    }

  }


            

