using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public int hp = 1;
	
	Spaceship spaceship;

	IEnumerator Start ()
	{
		for (int i = 0; i < 10; i++) {
			GameObject.Find ("Manager");
			GameObject.Find ("Player(Clone)");
		}

		spaceship = GetComponent<Spaceship> ();

		Move (transform.up * -1);

		if (spaceship.canShot == false) {
			yield break;
		}
			
		while (true) {

			for (int i = 0; i < transform.childCount; i++) {
				
				Transform shotPosition = transform.GetChild (i);

				spaceship.Shot (shotPosition);
			}

			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	public void Move (Vector2 direction)
	{
		rigidbody2D.velocity = direction * spaceship.speed;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.tag != "PlayerBullet") return;

		hp = hp - c.transform.GetComponent<Bullet>().power;

		Destroy(c.gameObject);

		if(hp <= 0 )
		{
			spaceship.Explosion ();

			Destroy (gameObject);
		}else{
			spaceship.GetAnimator().SetTrigger("Damage");
		}
	}
}