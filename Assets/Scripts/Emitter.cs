using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
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
			Instantiate (enemy, pos, Quaternion.identity);

			yield return new WaitForSeconds(rate);
		}
	}
}