using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DonutTriger : MonoBehaviour
{
    [SerializeField] private GameObject _questMessage;
    [SerializeField] private AudioClip _donutPickupSound;

    public float activationDuration = 2f;

    private DonutQuest _donutQuest;
    private bool _soundPlayed = false;

    void Awake()
    {
        _questMessage.SetActive(false);
        _donutQuest = FindObjectOfType<DonutQuest>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_soundPlayed == false)
            {
                AudioSource.PlayClipAtPoint(_donutPickupSound, transform.position);
                _soundPlayed= true;
            }

            _donutQuest.playerHasDonut = true;
            StartCoroutine(ActivateObjectTemporary());
        }
    }

    private IEnumerator ActivateObjectTemporary()
    {
        _questMessage.SetActive(true);

        yield return new WaitForSeconds(activationDuration);

        _questMessage.SetActive(false);
        Destroy(gameObject);
    }

}
