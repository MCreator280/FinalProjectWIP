using System.Collections.Generic;
using UnityEngine;


public class GhostScript : MonoBehaviour
{

    public SpriteRenderer SR;
    public Rigidbody2D RB;

    //Ghost Stats
    public float Speed = 5;
    public float JumpPower = 10;
    public float Gravity = 13;

    //Ghost States
    public List<GameObject> Touching;
    public bool PlayerControl = true;
    public bool OnGround = false;
    public float Dash = 0;
    public bool FacingLeft = false;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB.gravityScale = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl != true) return;
        
        Vector2 vel = RB.linearVelocity;

        if(Dash > 0)
        {
            Dash -= Time.deltaTime;
            if (FacingLeft)
            {
                vel = new Vector2(-15,0);
            }
            else
            {
                vel = new Vector2(15,0);
            }
            RB.linearVelocity = vel;
            return;
        }

        //Assigns Vel to be LinearVelocity
        
        
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            Dash = 0.2f;
        }
        
    
    

        //Updates LinearVelocity to match what Vel is equal at the moment
        RB.linearVelocity = vel;
        

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



}
