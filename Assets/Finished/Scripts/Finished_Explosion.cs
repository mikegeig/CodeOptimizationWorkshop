using UnityEngine;

public class Finished_Explosion : MonoBehaviour
{
	void Awake()
	{
		gameObject.SetActive(false);
	}

	void OnEnable()
	{
		Invoke ("Die", 1f);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}

	void Die ()
	{
		ObjectPool.instance.PoolObject(gameObject);
	}
}