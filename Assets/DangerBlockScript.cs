using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerBlockScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GhostScript GS = other.gameObject.GetComponent<GhostScript>();

        if(GS != null)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
