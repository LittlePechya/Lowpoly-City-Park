using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashController : MonoBehaviour
{
    [SerializeField] private Image _questImage;
    public int totalTrashCount;
    public int collectedTrashCount = 0;
    public bool questComplete = false;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _questCompleteSound;

    private void Start()
    {
        totalTrashCount = transform.childCount;
        _audioSource = GetComponent<AudioSource>();
        Debug.Log(totalTrashCount);

        setColor(0.25f);
    }

    private void Update()
    {
        if (collectedTrashCount >= totalTrashCount)
        {
            setColor(1f);

            if (questComplete == false)
            {
                _audioSource.PlayOneShot(_questCompleteSound);
                questComplete = true;
            }

        }
    }

    private void setColor(float alphaValue)
    {
        Color imageColor = _questImage.color;
        imageColor.a = alphaValue;
        _questImage.color = imageColor;
    }

}
