using UnityEngine;

public class Finished_DestroyArea : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D c)
	{
		ObjectPool.instance.PoolObject(c.gameObject);
	}
}