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
            isMovingRight = true;
            //isMovingUp = false;
            this.transform.position += (Vector3.right * Time.deltaTime) * moveSpeed;
            this.transform.localScale = new Vector3(1, 1, 1);
            rightHand.SetActive(true);
            LightSlash(new Vector2(rightHand.transform.position.x, rightHand.transform.position.y));
        }
        else if (horizontalMove < 0.0)
        {
            isMovingRight = false;
            //isMovingUp = false;
            this.transform.position -= (Vector3.right * Time.deltaTime) * moveSpeed;
            this.transform.localScale = new Vector3(-1, 1, 1);
            rightHand.SetActive(true);
            LightSlash(new Vector2(rightHand.transform.position.x, rightHand.transform.position.y));
        }
        else if (horizontalMove == 0.0)
        {
            //isMovingUp = false;
            isMovingRight = false;
            rightHand.SetActive(false);
        }


        if (verticalMove > 0.0)
        {
            isMovingRight = false;
            isMovingUp = true;
            this.transform.position += (Vector3.up * Time.deltaTime) * moveSpeed;
            topHand.SetActive(true);
            LightSlash(new Vector2(topHand.transform.position.x, topHand.transform.position.y));
        }
        else if (verticalMove < 0.0)
        {
            isMovingUp = false;
            this.transform.position -= (Vector3.up * Time.deltaTime) * moveSpeed;
            bottomHand.SetActive(true);
            LightSlash(new Vector2(bottomHand.transform.position.x, bottomHand.transform.position.y));
        }
        else if (verticalMove == 0.0)
        {
            isMovingUp = false;
            topHand.SetActive(false);
            bottomHand.SetActive(false);
        }





        if (player.GetButtonDown("Light Attack"))
        {
            //checking attack direction based off movement
            if (verticalMove > 0.0 || horizontalMove > 0.0)
            {
                if (verticalMove > horizontalMove)
                {
                    Debug.Log("AttackUp");

                }
                else
                {
                    Debug.Log("AttackRight");

                    // StartCoroutine("LightSlash");
                    // rightHandSword.transform.Rotate(Vector3.Lerp(Vector3.zero, new Vector3(0, 0, -50), slashSmoothspeed));
                }
            }
            else if (verticalMove < 0.0 || horizontalMove < 0.0)
            {
                if (verticalMove < horizontalMove)
                {
                    Debug.Log("AttackDown");
                }
                else
                {
                    Debug.Log("AttackLeft");
                }
            }
        }


    }

    private void LightSlash(Vector2 start)
    {


        if (isMovingUp)
        {
            Vector2 tempend = start + new Vector2(0, 1);
            RaycastHit2D temphit = Physics2D.Linecast(start, tempend);
            Debug.DrawLine(start, tempend, Color.red);

            Vector2 tempend1 = start + new Vector2(0.5f, 1);
            RaycastHit2D temphit1 = Physics2D.Linecast(start, tempend1);
            Debug.DrawLine(start, tempend1, Color.red);

            Vector2 tempend2 = start + new Vector2(-0.5f, 1);
            RaycastHit2D temphit2 = Physics2D.Linecast(start, tempend2);
            Debug.DrawLine(start, tempend2, Color.red);

        }
        else
        {
            Vector2 tempend = start + new Vector2(0, -1);
            RaycastHit2D temphit = Physics2D.Linecast(start, tempend);
            Debug.DrawLine(start, tempend, Color.red);

            Vector2 tempend1 = start + new Vector2(0.5f, -1);
            RaycastHit2D temphit1 = Physics2D.Linecast(start, tempend1);
            Debug.DrawLine(start, tempend1, Color.red);

            Vector2 tempend2 = start + new Vector2(-0.5f, -1);
            RaycastHit2D temphit2 = Physics2D.Linecast(start, tempend2);
            Debug.DrawLine(start, tempend2, Color.red);
        }
       

       

    }
    }


            

