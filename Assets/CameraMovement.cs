using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GhostScript Ghost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Ghost.transform.position + new Vector3 (0,2,-10);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = Ghost.transform.position + new Vector3 (-2,1,-10);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = Ghost.transform.position + new Vector3 (2,1,-10);
        }
        else
        {
            transform.position = Ghost.transform.position + new Vector3 (0,1,-10);
        }
    }
}
