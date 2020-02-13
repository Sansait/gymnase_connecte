using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CRI.HitBoxTemplate.ScoreManager;

public class BallMovement : MonoBehaviour
{
	[SerializeField]
	private float init_speed = 0.02f;
	[SerializeField]
	private float _speed_inc = 0.01f;
	private float _speed;
	private Vector3 _direction = Vector3.left;
	private int counter = 0;

	// Start is called before the first frame update
	void Start()
    {
		_speed = 0;
		_direction = RotatePointAroundAxis(_direction, Random.Range(-45, 46), Vector3.up);
		if (Random.Range(0, 2) == 0)
			_direction = -_direction;
    }

	void New_Ball()
	{
		this.transform.position = Vector3.zero;
		
		_speed = 0;
		counter = 0;
		_direction = RotatePointAroundAxis(_direction, Random.Range(-45, 46), Vector3.up);
	}

	private void Collision_PlayerBar(Collision collision)
	{
		Vector3 contactPoint = collision.GetContact(0).point;
		float angle = (contactPoint.z - collision.transform.position.z) * 18;

		if (collision.gameObject.name == "Mass1")
			_direction = RotatePointAroundAxis(Vector3.left, angle, Vector3.up);
		else
			_direction = RotatePointAroundAxis(Vector3.right, angle, Vector3.down);
		_speed += _speed_inc;
	}

	private void Collision_Wall(Collision collision)
	{
		if (collision.gameObject.name == "Upper")
			_direction = Vector3.Reflect(_direction, Vector3.back);
		else if (collision.gameObject.name == "Lower")
			_direction = Vector3.Reflect(_direction, Vector3.forward);
	}

	void Score(Collision collision)
	{
		if (collision.gameObject.name == "Blue Team (1)")
		{
			_direction = Vector3.left;
			ScoreManager.Instance.redScore++;
			Debug.Log("Red Team Scores");
			New_Ball();
		}
		else if (collision.gameObject.name == "Red Team (2)")
		{
			_direction = Vector3.right;
			ScoreManager.Instance.blueScore++;
			Debug.Log("Blue Team Scores");
			New_Ball();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "PlayerBar")
			Collision_PlayerBar(collision);
		else if (collision.gameObject.tag == "Wall")
			Collision_Wall(collision);
		else if (collision.gameObject.tag == "Goal")
			Score(collision);
	}

	// Update is called once per frame
	void Update()
    {
		if (counter < 50)
			counter++;
		else if (counter == 50)
		{
			_speed = init_speed;
			counter++;
		}
		else
		{
			//Debug.DrawRay(this.transform.position, _direction * 2);
			this.transform.position += (_direction * _speed) / Time.deltaTime;
		}
	}

	private Vector3 RotatePointAroundAxis(Vector3 point, float angle, Vector3 axis)
	{
		Quaternion q = Quaternion.AngleAxis(angle, axis);
		return q * point;
	}
}
