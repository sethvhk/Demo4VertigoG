using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText1; 
	public Text winText1;
	public AudioClip pickupsound;
	public AudioClip winnerwinner;
	private int count;

	void Start (){
		count = 0;
		SetCountText ();
		winText1.text = "";
	}

	void FixedUpdate () {

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (x, 0.0f, y);
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Zombie") {

            other.gameObject.tag = "Dead"; //but arent zombies already dead?

            other.gameObject.GetComponent<LookAt>().enabled = false; //youre dead stop looking at me
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = false; //lumpy corpse     
            other.gameObject.AddComponent<Rigidbody>(); //flop
            GetComponent<AudioSource>().PlayOneShot(pickupsound, 1.0F); //bleeeeghhrrarrah   

            count = count + 1;
			SetCountText ();
            //StartCoroutine(Dying(other.gameObject, -90f, 1.0f));
        }
	}

    void SetCountText(){
        countText1.text = "Hit the zombies! " + count.ToString() + " / 5";
		if (count >= 5) {
			winText1.text = "YOU WIN!";
            countText1.text = "SURVIVED 5/5";
            GetComponent<AudioSource>().PlayOneShot(winnerwinner, 1.0F);
		}
	}

    //old death animation, use physics/rigidbody instead
    IEnumerator Dying(GameObject g, float newangle, float overTime)
    {
        float startTime = Time.time;
        Vector3 currentRotation = g.transform.eulerAngles;
        float newRotation = currentRotation.x + newangle;

        while (Time.time < startTime + overTime)
        {
            currentRotation.x = Mathf.Lerp(currentRotation.x, newRotation, (Time.time - startTime) / overTime);
            g.transform.eulerAngles = currentRotation;
            yield return null;
        }
    }
}