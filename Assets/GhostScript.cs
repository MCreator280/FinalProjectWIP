using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GhostScript : MonoBehaviour
{

    public SpriteRenderer SR;
    public Rigidbody2D RB;
    public TextMeshPro SEnergy;
    

    //Ghost Stats
    public float Speed = 5;
    public float JumpPower = 10;
    public float Gravity = 13;
    public float CooldownDash = 3;
    public float CooldownTimerD = 0;

    //Ghost States
    public List<GameObject> Touching;
    public bool PlayerControl = true;
    public bool OnGround = false;
    public float Dash = 0;
    public bool FacingLeft = false;
    public bool DashState = false;


    //Ghost Collects
    // public float SmallEnergy = 0;
    //public GameObject GhostWall;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB.gravityScale = Gravity;
        //GhostWall = GetComponent<Collider2D>();
        // GWState.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl != true) return;
        
        Vector2 vel = RB.linearVelocity;

        // if (Input.GetKeyDown(KeyCode.C) && CooldownTimerD <=0 )
        // {
        //     CooldownTimerD = CooldownDash;
        // }

        if (CooldownTimerD >= 0)
        {
            CooldownTimerD -= Time.deltaTime;
            SR.color = Color.grey;
                    if(Dash > 0)
                {
                    Dash -= Time.deltaTime;
                    if (FacingLeft)
                    {
                        vel = new Vector2(-25,0);
                    }
                    else
                    {
                        vel = new Vector2(25,0);
                    }
                    DashState = true;
                    RB.linearVelocity = vel;
                    return;
                }
            else
            {
                DashState = false;
            }
            Debug.Log("I Can't Dash");
        }
        else
        {
            SR.color = Color.white;
        }

      
        
        //Movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
            Debug.Log("Right");
            FacingLeft = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
            Debug.Log("Left");
            FacingLeft = true;
        }
        else
        {
            vel.x = 0;
        }


        //Jump
        if (Input.GetKeyDown(KeyCode.Z) && CanJump())
        {
            vel.y = JumpPower;
        }

        if (Input.GetKeyDown(KeyCode.X) && CooldownTimerD <= 0)
        {
            Dash = 0.2f;
            CooldownTimerD = CooldownDash;
        }
        
        
    

        //Updates LinearVelocity to match what Vel is equal at the moment
        RB.linearVelocity = vel;
        

        SEnergy.text= "Small Energy "+ GM.SmallE;


    }

    public bool CanJump()
    {
        return Touching.Count > 0;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!Touching.Contains(other.gameObject))
            Touching.Add(other.gameObject);



    }

    private void OnCollisionExit2D(Collision2D other)
    {
        OnGround = false;
        Touching.Remove(other.gameObject);
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        OnGround = false;
        Touching.Remove(other.gameObject);
    }
    


}
