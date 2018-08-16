using UnityEngine;

public class obstacleDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boulder" || collision.gameObject.tag == "Puddle")
        {
            Destroy(collision.gameObject);
        }
    }
}
