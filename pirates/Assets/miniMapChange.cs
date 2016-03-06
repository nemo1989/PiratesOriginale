using UnityEngine;
using System.Collections;

public class miniMapChange : MonoBehaviour {

	public GameObject miniMap1;
	public GameObject miniMap2;

	// Use this for initialization
	void Start () {
		miniMap2.SetActive (false);
	}
	
	void OnTriggerEnter2D(Collider2D collide)
	{
		if (collide.gameObject.tag == "Player") {
			Debug.Log("dsoj");
			miniMap2.SetActive (true);
			miniMap1.SetActive (false);
	}
}
	void OnTriggerExit2D(Collider2D colide)
	{
		miniMap1.SetActive (true);
		miniMap2.SetActive (false);

	}
}
