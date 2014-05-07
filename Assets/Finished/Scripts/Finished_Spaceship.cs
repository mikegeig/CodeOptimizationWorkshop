using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Finished_Spaceship : MonoBehaviour
{
	public float speed;
	public float shotDelay;
	public string bullet;
	public bool canShot;
	public string explosion;
	
	private Animator animator;

	void Awake ()
	{
		animator = GetComponent<Animator> ();
	}
	
	public void Explosion ()
	{
		GameObject obj = ObjectPool.instance.GetObjectForType(explosion, true);
		if(obj == null) return;
		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive(true);
	}

	public void Shot (Transform origin)
	{
		GameObject obj = ObjectPool.instance.GetObjectForType(bullet, true);
		if(obj == null) return;
		obj.transform.position = origin.position;
		obj.transform.rotation = origin.rotation;
		obj.SetActive(true);
	}
	
	public Animator GetAnimator()
	{
		return animator;
	}
}