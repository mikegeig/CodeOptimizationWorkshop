using UnityEngine;

public class Finished_Bullet : MonoBehaviour
{
	public int speed = 10;
	
	public float lifeTime = 1;
	
	public int power = 1;

	void Awake ()
	{
		GameObject.Find ("Manager");
		GameObject.Find ("Player(Clone)");

		gameObject.SetActive(false);
	}

	void OnEnable()
	{
		rigidbody2D.velocity = transform.up.normalized * speed;

		Invoke ("Die", lifeTime);
	}

	void OnDisable()
	{
		CancelInvoke();
	}

	void Die()
	{
		ObjectPool.instance.PoolObject(gameObject);
	}
}