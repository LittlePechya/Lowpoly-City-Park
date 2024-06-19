using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    [SerializeField] private AudioClip _trashPickupSound;
    private TrashController _trashController;

    private void Start()
    {
        _trashController = FindObjectOfType<TrashController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _trashController.collectedTrashCount++;
            AudioSource.PlayClipAtPoint(_trashPickupSound, transform.position);
            Destroy(gameObject);
        }
    }
}
