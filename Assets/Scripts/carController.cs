using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class carController : MonoBehaviour {

    public float carSpeed;
    public float maxPos; // This is the maximum horizontal distance the car can go

    Vector3 position;
    public uiManager ui;
    public audioManager am;
    SpriteRenderer rend;

    private void Awake()
    {
        am.mainBg.Play();
    }

    // Use this for initialization
    void Start () {
        // transform.position is the current position of the car
        position = transform.position;
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        // Increment the horizontal position by whatever values we get 
		move();
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

        // Horizontal position will only be limited to -2.2f and 2.2f
        position.x = Mathf.Clamp(position.x, (-1*maxPos), maxPos);

        transform.position = position;
	}

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        ui.gameOverActivated(true);
        am.mainBg.Stop();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Boulder" || col.gameObject.tag == "Puddle")
        {
            ui.stopScoreUpdate();
            Destroy(col.gameObject);
            StartCoroutine("FadeOut");

            //Destroy(gameObject);
            //ui.gameOverActivated(true);
            //am.mainBg.Stop();
        }
    }

	public void move(){
		position.x += CrossPlatformInputManager.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
	}
}
