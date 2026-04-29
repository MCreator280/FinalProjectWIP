using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public SpriteRenderer SR;
    public Rigidbody2D RB;

    //Enemy Stats
    public float Speed = 5;
    public float JumpPower = 10;
    public float Gravity = 13;

    //Enemy States
    public bool PlayerControl = false;
    public bool OnGround = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl == true)
        {   
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
        if (other.gameObject.tag == "Ghost")
        {
            PlayerControl = true;
            SR.color = Color.blue;
            Destroy(other.gameObject);
        }
        
        OnGround = true;

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        OnGround = false;
    }


}
