﻿using UnityEngine;

public class Background : MonoBehaviour
{
	public float speed = 0.1f;
	
	void Update ()
	{
		float y = Mathf.Repeat (Time.time * speed, 1);

		Vector2 offset = new Vector2 (0, y);

		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}