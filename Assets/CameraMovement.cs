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
        //transform.position = Ghost.transform.position + new Vector3 (2,0,-10);

        if (Ghost.FacingLeft == false)
        {
            transform.position = Ghost.transform.position + new Vector3 (2,0,-10);
        }
        else 
        {
            transform.position = Ghost.transform.position + new Vector3 (-2,0,-10);
        }
    }
}
