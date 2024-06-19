using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;
    private int scoreValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);

            ScoreManager.instance.AddScore(scoreValue);

            Destroy(gameObject);
        }
    }
}
