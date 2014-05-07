using UnityEngine;

public class Finished_Explosion : MonoBehaviour
{
	void Awake()
	{
		gameObject.SetActive(false);
	}

	void OnAnimationFinish ()
	{
		ObjectPool.instance.PoolObject(gameObject);
	}
}