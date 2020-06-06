using UnityEngine;

public class ball : MonoBehaviour
{

    public Vector2 startForce;   // adding forces for x and y directions
    public Rigidbody2D rb;   // adding rigit body to the ball
    public GameObject nextBall;
    void Start()
    {
        rb.AddForce(startForce,ForceMode2D.Impulse);  // adding the forces to act on the rigid body
    }

    public void split()
    {
        if (nextBall != null) //generating new balls when hit by laser
        { 
            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
            // better to use rb.position as it gives only x and y wheras transform gives x,y,z  we use quaternion to ensure no rotation

            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);   // after instasiating we save it in a new game object 

            ball1.GetComponent<ball>().startForce = new Vector2(2f, 5f);     // applies upward momentum each time we split them in half  
            ball2.GetComponent<ball>().startForce = new Vector2(-2f, 5f);  // values applied are negative as we want them to go in the opposite direction
        }
        Destroy(gameObject);
    }
}
