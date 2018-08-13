using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

    public float carSpeed;
    public float maxPos = 2.2f; // This is the maximum horizontal distance the car can go

    Vector3 position;
    public uiManager ui;
    public audioManager am;

    private void Awake()
    {
        am.mainBg.Play();
    }

    // Use this for initialization
    void Start () {
        // transform.position is the current position of the car
        position = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        // Increment the horizontal position by whatever values we get 
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

        // Horizontal position will only be limited to -2.2f and 2.2f
        position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);

        transform.position = position;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Boulder") {
            Destroy(gameObject);
            ui.gameOverActivated(true);
            am.mainBg.Stop();
        }
    }
}
