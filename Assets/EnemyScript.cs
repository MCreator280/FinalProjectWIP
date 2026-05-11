using UnityEngine;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{

    public SpriteRenderer SR;
    public Rigidbody2D RB;
    public GhostScript Ghost;

    //Enemy Stats
    public float Speed = 5;
    public float WalkSpeed = 5;
    public float TopSpeed = 7;
    public float JumpPower = 10;
    public float Gravity = 13;
    public float SprintMulty = 1.5f;


    //Enemy States
    //public bool PlayerControl = false;
    public bool OnGround = false;
    public bool SprintState = false;

     public List<GameObject> Touching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB.gravityScale = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        //No longer inside of the cube, it will be empty the cube
        if (Ghost != null)
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

            //Sprint
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Speed = Mathf.Lerp(Speed,TopSpeed,0.1f);
                SprintState = true;
            }
            else
            {
                Speed = Mathf.Lerp(Speed,WalkSpeed,0.1f);
                SprintState = false;
            }

           if (Input.GetKeyDown(KeyCode.X))
            {
                Ghost.transform.position = transform.position + new Vector3 (2,0,0);
                Debug.Log("Not in them anymore");
                Ghost.gameObject.SetActive(true);
                Ghost.transform.parent = null;
                Ghost = null;
                SR.color = Color.red;
    
            }

            //Updates LinearVelocity to match what Vel is equal at the moment
            RB.linearVelocity = vel;
        }


    }

    public bool CanJump()
    {
        return Touching.Count > 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            //PlayerControl = true;
            Ghost = other.gameObject.GetComponent<GhostScript>();
            SR.color = Color.blue;
            other.gameObject.SetActive(false);
            other.transform.parent=transform;
            other.transform.localPosition = new Vector3(0,0,0);        
        }
        
        OnGround = true;
        if(!Touching.Contains(other.gameObject))
            Touching.Add(other.gameObject);

        if(other.gameObject.tag == "BreakableWall" && SprintState)
        {
           Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        OnGround = false;
        Touching.Remove(other.gameObject);
    }


}
