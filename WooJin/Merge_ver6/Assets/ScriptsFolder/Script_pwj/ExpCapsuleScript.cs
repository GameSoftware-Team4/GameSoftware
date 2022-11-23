using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCapsuleScript : MonoBehaviour
{
    GameManagerScript_pwj gameManager;
    Vector3 vc;
    // Start is called before the first frame update
    void Start()
    {
        vc = new Vector3(1f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vc);
        Destroy(gameObject, 60f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("°æÇèÄ¡ È¹µæ!");
            transform.position = other.transform.position;
            gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript_pwj>();
            if (gameManager != null) { gameManager.SetExp(); Destroy(gameObject); return; }
        }
    }
}
