using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public static int coinScore;

    private static AudioClip audioClip;
    private float rotateSpeed = 50;
    private static GameObject effectPrefab;

    void Start()
    {
        coinScore = 0;


        if (audioClip == null)
        {
            audioClip = Resources.Load<AudioClip>("smw_coin");
            effectPrefab = Resources.Load("coin_effect") as GameObject;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<CharacterController>() != null)
            PickupCoin();
    }

    private void PickupCoin()
    {
        if (audioClip != null)
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        coinScore++;

        if (effectPrefab != null)
        {
            GameObject fireworks = Instantiate(effectPrefab) as GameObject;
            fireworks.transform.position = transform.position;
            Destroy(fireworks, 5);
        }

        Destroy(gameObject);
    }
}
