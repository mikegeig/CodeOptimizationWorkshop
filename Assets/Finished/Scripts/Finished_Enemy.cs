using UnityEngine;
using System.Collections;

public class Finished_Enemy : MonoBehaviour
{
	public int hp = 1;
	
	Finished_Spaceship spaceship;

	void Awake ()
	{
		GameObject.Find ("Manager");
		GameObject.Find ("Player(Clone)");

		spaceship = GetComponent<Finished_Spaceship> ();
		gameObject.SetActive(false);
	}

	void OnEnable()
	{
		StartCoroutine("Process");
	}

	void OnDisable()
	{
		StopCoroutine("Process");
	}

	IEnumerator Process()
	{
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

		hp = hp - c.transform.GetComponent<Finished_Bullet>().power;

		ObjectPool.instance.PoolObject(c.gameObject);

		if(hp <= 0 )
		{
			spaceship.Explosion ();

			ObjectPool.instance.PoolObject(gameObject);
		}else{
			spaceship.GetAnimator().SetTrigger("Damage");
		}
	}
}