using UnityEngine;

public class GhostWallScript : MonoBehaviour
{

    public BoxCollider2D GWCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GWCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        GhostScript GW = other.gameObject.GetComponent<GhostScript>();

             if(GW != null && GW.DashState)
         {
             GWCollider.isTrigger = true;
         }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GWCollider.isTrigger = false;
    }
}
