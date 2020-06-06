using UnityEngine;

public class chaincollision : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)    // whenever a collider enter the schene then unity triggers this
	{
		chain.IsFired = false;

		if (col.tag == "ball")
		{
			col.GetComponent<ball>().split();
		}
	}

}
