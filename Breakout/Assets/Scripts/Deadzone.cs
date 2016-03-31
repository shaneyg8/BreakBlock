using UnityEngine;
using System.Collections;

public class Deadzone : MonoBehaviour {
	
	void OnTriggerEnter (Collider col)
	{
		GM.instance.LoseLife();
	}
}