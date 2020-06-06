using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed = 4f;    // to store the players speed

    public Rigidbody2D rb;               //refernce to our rigidbody 


    private float movement = 0f;

    void Update()
    {
        movement =Input.GetAxis("Horizontal") * speed;        //to gather some input  allows us to specify if we want input for horizontal or vertical if -1 left and 0 then no input 1 is right
    }

    void FixedUpdate() // actual player movement unity uses this to calculate physics
    {
        rb.MovePosition(rb.position + new Vector2( movement * Time.fixedDeltaTime ,0f));      // for movement of rigid body takes 2 vales x and y here we are giving current position and movement
    }

    void OnCollisionEnter2D(Collision2D col)    // better  as we obtain collision information which does not happen in case of trigger
    {
        if (col.collider.tag == "ball")
        {
            Debug.Log("GAME OVER!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
