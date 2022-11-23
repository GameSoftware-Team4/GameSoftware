using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
	public List<GameObject> foundObj;
	public GameObject enemy;
	public string tagName;
	public float shortDis;

	Quaternion quat = Quaternion.identity;
	// Start is called before the first frame update
	void Start()
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
		// 에임 조준
		if(enemy != null)
			Aim();
        else // 조준했던 오브젝트가 파괴된다면, 다시 조준
        {
			FindEnemy();
        }

    }
    private void Aim()
    {
		Vector3 _direction = (enemy.transform.position - transform.position).normalized;
		Quaternion _lookRoation = Quaternion.LookRotation(_direction);
		Quaternion _rotation = Quaternion.Lerp(transform.rotation, _lookRoation, 0.2f);
		transform.rotation = _rotation;
    }

    private void Update()
    {
		Destroy(gameObject, 15f);
    }
}
