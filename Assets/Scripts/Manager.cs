using UnityEngine;

public class Manager : MonoBehaviour
{
	public GameObject player;
	public GameObject title;
	
	void Update ()
	{
		if (IsPlaying () == false && Input.GetKeyDown (KeyCode.X)) {
			GameStart ();
		}
	}
	
	void GameStart ()
	{
		title.SetActive (false);
		Instantiate (player, player.transform.position, player.transform.rotation);
	}
	
	public bool IsPlaying ()
	{
		return title.activeSelf == false;
	}
}