using UnityEngine;
using System.Collections;

public class Finished_Player : MonoBehaviour
{
	Finished_Spaceship spaceship;
	Vector2 min;
	Vector2 max;
	
	IEnumerator Start ()
	{
		spaceship = GetComponent<Finished_Spaceship> ();
		min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		
		while (true) {

			for (int i = 0; i < transform.childCount; i++) {
				
				Transform shotPosition = transform.GetChild (i);
				
				spaceship.Shot (shotPosition);
			}

			audio.Play();

			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	void Update ()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		Vector2 direction = new Vector2 (x, y);

		Move (direction);
	}


	void Move (Vector2 direction)
	{
		Vector2 pos = transform.position;

		pos += direction  * spaceship.speed * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		transform.position = pos;
	}
}