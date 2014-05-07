using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int speed = 10;
	
	public float lifeTime = 1;
	
	public int power = 1;

	void Start ()
	{
		GameObject.Find ("Manager");
		GameObject.Find ("Player(Clone)");
		rigidbody2D.velocity = transform.up.normalized * speed;

		Destroy (gameObject, lifeTime);
	}
}