using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
	public Mob mobScript;
	public List<GameObject> foundObj;
	public GameObject enemy;
	public string tagName = "Monster";
	public float shortDis;
	GameObject child = null;
	public float shotDelay = 0;

	public ParticleSystem muzzleFlash;
	public Transform flashPoint;
	private float turretDamage = 100;
	RaycastHit hit;
	int layerMask;

	Quaternion quat = Quaternion.identity;
	// Start is called before the first frame update
	void Start()
	{
        muzzleFlash = Resources.Load<ParticleSystem>("pwj_prefab/WFX_MF FPS RIFLE3");
		// GameObject currentObj = Resources.Load<GameObject>("pwj_prefab/turretPref");
		flashPoint = transform.GetChild(2).gameObject.transform;
		child = transform.GetChild(1).gameObject;
		quat.eulerAngles = new Vector3(90, 0, 0);
		foundObj = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
		shortDis = Vector3.Distance(gameObject.transform.position, foundObj[0].transform.position);
		layerMask = 1 << LayerMask.NameToLayer("Monster");

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
		mobScript = enemy.GetComponent<Mob>();
		Debug.Log(enemy.name + "sdsds");
	}

	private void FindEnemy()
    {
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

    private void FixedUpdate()
    {
		// ???? ????
		if (enemy != null)
		{
			shotDelay += Time.deltaTime;
			Aim();
			if (shotDelay > 5f)
			{
				DrawRay();
			}

		}
		else // ???????? ?????????? ??????????, ???? ????
		{
			FindEnemy();
		}

    }

    private void Update()
    {
		Destroy(gameObject, 12f);
    }
    private void Aim()
    {
		Vector3 _direction = (enemy.transform.position - transform.position).normalized;
		Quaternion _lookRoation = Quaternion.LookRotation(_direction);
		Quaternion _rotation = Quaternion.Lerp(transform.rotation, _lookRoation, 0.2f);
		transform.rotation = _rotation;
    }

	/*private void DrawRay()
    {
		if(Physics.Raycast(transform.position, transform.forward, out hit, 50f))
        {
			mobScript.curHealth -= 5;
			// Debug.Log(hit.collider.transform.position);
			shotDelay = 0;
        }
        else
        {
			Debug.Log("Target missing");
			return;
        }
    }*/
	private void DrawRay()
	{

		if (Physics.Raycast(transform.position, transform.forward, out hit, 50f, layerMask))
		{
			hit.transform.GetComponent<Mob>().OnTurretDamage(turretDamage, transform.position);
			ParticleSystem instance = Instantiate(muzzleFlash, flashPoint.position, flashPoint.rotation);
			instance.Play();
			shotDelay = 0;
		}
		else
		{
			Debug.Log("Target missing");
			return;
		}
	}
}
