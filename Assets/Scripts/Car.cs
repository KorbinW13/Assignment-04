using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;
	public GameObject car;

	public float minSpeed = 8f;
	public float maxSpeed = 12f;

	float speed = Settings.CarSpeed;

	void Start ()
	{
		minSpeed= Settings.CarSpeed;
		maxSpeed= (Settings.CarSpeed + Settings.CarSpeed);
		speed = Random.Range(minSpeed, maxSpeed);
		Invoke("DestroyCar", 3.0f);
	}

	void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

	void DestroyCar()
	{
        Destroy(car);
    }
}
