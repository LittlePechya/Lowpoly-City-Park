using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _beachBall;
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private int mininalHeight = 6;
    // Update is called once per frame
    void Update()
    {
        if (_player.transform.position.y < mininalHeight)
        {
            _player.transform.position = spawnPosition.transform.position;
        }

        if (_beachBall.transform.position.y < mininalHeight)
        {
            _beachBall.transform.position = spawnPosition.transform.position;
        }

    }
}
