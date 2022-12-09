using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript_pwj : MonoBehaviour
{
	public List<GameObject> foundObj;
	public GameObject enemy;
	public string tagName = "Monster";
	public float shortDis;
	public GameObject explosionParticle;

	public GameObject goo;
	public Rigidbody missileRig;
	public float missileSpeed = 5.0f;
	public float turn = 3.0f;
	Quaternion quat = Quaternion.identity;
    // Start is called before the first frame update
    private void Awake()
    {
		explosionParticle = Resources.Load<GameObject>("pwj_prefab/rocket_ep");

		// missileRig = Resources.Load<GameObject>("pwj_prefab/Missile").GetComponent<Rigidbody>();
		goo = Resources.Load<GameObject>("pwj_prefab/Missile");
		missileRig = goo.GetComponent<Rigidbody>();

		// missileRig = Resources.Load<GameObject>("pwj_prefab/Missile").GetComponent<Rigidbody>();
	}
	void Start()
	{
		/*explosionParticle = Resources.Load<GameObject>("pwj_prefab/rocket_ep");

		// missileRig = Resources.Load<GameObject>("pwj_prefab/Missile").GetComponent<Rigidbody>();
		goo = Resources.Load<GameObject>("pwj_prefab/Missile");
		missileRig = goo.GetComponent<Rigidbody>();
*/

		quat.eulerAngles = new Vector3(90, 0, 0);
		foundObj = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
		shortDis = Vector3.Distance(gameObject.transform.position, foundObj[0].transform.position);

		enemy = foundObj[0];

		foreach (GameObject found in foundObj)
		{
			float distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

			if (distance < shortDis)
			{
				enemy = found;
				shortDis = distance;
			}
		}
		Debug.Log(enemy.name);
	}

	// Update is called once per frame
	void Update()
	{
		
		if (enemy == null)
		{
			Destroy(gameObject);
			return;
		}
		else
			Fly();
	}
	private void Fly()
    {
		/*missileRig.velocity = transform.forward * missileSpeed;
		var targetRotation = Quaternion.LookRotation(enemy.transform.position + new Vector3(0, 0.8f) - transform.position);
		missileRig.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));*/

		transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, missileSpeed * Time.deltaTime);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Monster") || collision.collider.CompareTag("Terrain"))
		{
			Destroy(this.gameObject);
			GameObject obj = Instantiate(explosionParticle, transform.position, Quaternion.identity);
			// Destroy(obj);
		}
	}
}
