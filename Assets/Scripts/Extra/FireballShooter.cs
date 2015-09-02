using UnityEngine;
using System.Collections;

public class FireballShooter : MonoBehaviour {

    GameObject fireballPrefab;
	private GameObject fireballContainer;
    private static AudioClip audioClip;

	void Start () {

		fireballContainer = new GameObject ("fireball container") as GameObject;

        if (audioClip == null)
        {
            audioClip = Resources.Load<AudioClip>("smw_fireball");
            fireballPrefab = Resources.Load("fireball") as GameObject;
        }
	}
	
	void Update () {
        //If we left click (right click is GetMouseButtonDown(1) )
        if (Input.GetMouseButtonDown(0) && fireballPrefab!=null)
        {
            //Make a new projectile.
            GameObject fireball = Instantiate(fireballPrefab) as GameObject;
            //Set the projectile position to our position, plus just a little bit in the direction we're looking,
            //so it appears in front of our face and not inside us.
            fireball.transform.position = transform.position + Camera.main.transform.forward * 2;

			//This step is not necessary, but it cleans up the Unity inspector. All projectiles will appear inside
			//just one gameobject in the inspector.
			fireball.transform.parent=fireballContainer.transform;

            //Find the RigidBody attached to that projectile so we can change its velocity.
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            
            //Set the velocity to equal the direction we are looking.
            //Say Camera.main.transform.forward = ( 1, 0.1, 0)
            //This is a 3D vector. It means we're looking in the positive x direction a lot, a little bit 
            //in the y direction (up), and not at all in the z direction.

            // ( 1, 0.1, 0) * 40 = (40,4,0)
            //Here we set our velocity to that, so the projectile flies fast in the direction we are looking.
            rb.velocity = Camera.main.transform.forward * 40;

            if (audioClip != null)
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
	}
}
