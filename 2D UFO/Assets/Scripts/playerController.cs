using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour {
	public float speed;
	public Text scoreText;
	public Text winText;

	private Rigidbody2D rb;
	private int count;
	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
		SetScoreText ();
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal,moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			SetScoreText ();
		}
	}
		void SetScoreText()
		{
		scoreText.text = "Score: " + count.ToString ();
		if (count >= 13) {
			winText.text="YOU WIN";
		}
		}
	
}
