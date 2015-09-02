using UnityEngine;
using System.Collections;

//If you attach this to a GameObject and it collides with something, it will explode in fireworks!
public class ExplodingProjectile : MonoBehaviour {
    GameObject effectPrefab;
    bool hasExploded = false;
    void Start()
    {
        //This finds a "prefab" in "Assets/Resources/Prefabs/fireworks".
        //You can also create your own but I already made one for you.
        effectPrefab = Resources.Load("fireball_effect") as GameObject;
    }

    //This method happens when something collides with this GameObject. We want to explode when we collide with anything.
	void OnCollisionEnter (Collision collision) {
        //Make sure that a simultaneous collision does not cause multiple explosions from one projectile.
        if (!hasExploded)
        {
            hasExploded = true;
            //In Java, you use a class to instantiate an object. Or, you use a class (which is an idea) to
            //make an instance (which is a real object). Here we're doing much the same thing. Using a "prefab"
            //idea to make a GameObject instance.
            GameObject fireballEffect = Instantiate(effectPrefab) as GameObject;
            //Set the position of the new fireworks GameObject to be the same position as the projectile.
            fireballEffect.transform.position = transform.position;

            //Destroy the fireworks in 5 seconds.
            Destroy(fireballEffect, 5);
            //Destroy the projectile now. This ExplodingProjectile also won't be able to run again because its container
            //GameObject will be gone!
            Destroy(gameObject);
        }
	}
}
