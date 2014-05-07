using UnityEngine;
using System.Collections;

public class Finished_Emitter : MonoBehaviour
{
	public GameObject enemy;
	public Manager manager;
	public float rate;
	
	IEnumerator Start ()
	{		
		while (true) {

			while(manager.IsPlaying() == false) {
				yield return new WaitForEndOfFrame ();
			}
			Vector3 pos = transform.position;
			pos.x += Random.Range(-3.5f, 3.5f);
			GameObject obj = ObjectPool.instance.GetObjectForType("Enemy", true);
			if(obj != null){
				obj.transform.position = pos;
				obj.transform.rotation = Quaternion.identity;
				obj.SetActive(true);
			}

			yield return new WaitForSeconds(rate);
		}
	}
}