using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GhostScript Ghost;
    public Vector3 Desired;// = Ghost.transform.position + new Vector3 (-2,1,-10);
    void Start()
    {
        transform.position = Ghost.transform.position + new Vector3 (0,1,-10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desired = Ghost.transform.position + new Vector3 (3,1,-10);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desired = Ghost.transform.position + new Vector3 (-3,1,-10);
        }
        else
        {
            Desired = Ghost.transform.position + new Vector3 (0,1,-10);
        }

        // transform.position = Ghost.transform.position + new Vector3 (0,2,-10);

        if (transform.position != Desired)
        {
            transform.position = Vector3.Lerp(transform.position, Desired, 0.12f);
        }
    }
}
