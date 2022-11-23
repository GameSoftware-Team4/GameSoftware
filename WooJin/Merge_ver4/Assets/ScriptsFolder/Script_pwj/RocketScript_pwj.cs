using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript_pwj : MonoBehaviour
{
	public List<GameObject> foundObj;
	public GameObject enemy;
	public string tagName;
	public float shortDis;
	public GameObject explosionParticle;

	public Rigidbody missileRig;
	public float missileSpeed = 5.0f;
	public float turn = 3.0f;
	Quaternion quat = Quaternion.identity;
	// Start is called before the first frame update
	void Start()
	{
		quat.eulerAngles = new Vector3(90, 0, 0);
		foundObj = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
		shortDis = Vector3.Distance(gameObject.transform.position, foundObj[0].transform.position);

		enemy = foundObj[0];

		foreach(GameObject found in foundObj)
		{
			float distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

			if(distance < shortDis)
			{
				enemy = found;
				shortDis = distance;
			}
		}
		Debug.Log(enemy.name);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (enemy == null)
		{
			Destroy(gameObject);
			return;
		}
		missileRig.velocity = transform.forward * missileSpeed;
		var targetRotation = Quaternion.LookRotation(enemy.transform.position + new Vector3(0, 0.8f) - transform.position);
		missileRig.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));
		// Debug.Log(transform.rotation);
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Monster") || collision.collider.CompareTag("Terrain"))
        {
			Destroy(this.gameObject);
			GameObject obj = Instantiate(explosionParticle, transform.position, Quaternion.identity);
			// Destroy(obj);
		}
    }
}
