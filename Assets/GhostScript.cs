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
    public bool PlayerControl = true;
    public bool OnGround = false;
    public float Dash = 0;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB.gravityScale = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl == true)
        {   

            if(Dash > 0)
            {
                Dash -= Time.deltaTime;
            }


            //Assigns Vel to be LinearVelocity
            Vector2 vel = RB.linearVelocity;
            
            //Movement
            if (Input.GetKey(KeyCode.RightArrow))
            {
                vel.x = Speed;
                Debug.Log("Right");
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                vel.x = -Speed;
                Debug.Log("Left");
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

            //Dash
            // if (Input.GetKeyDown(KeyCode.X))
            // {
            //     Dash = 0.75f;
            //     Vector2 vel = new Vector2(5,5);
            //     RB.AddForce(vel,ForceMode2D.Impulse);
            // }
            
            
        

            //Updates LinearVelocity to match what Vel is equal at the moment
            RB.linearVelocity = vel;
        }

    }

    public bool CanJump()
    {
        return OnGround;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnGround = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        OnGround = false;
    }



}
