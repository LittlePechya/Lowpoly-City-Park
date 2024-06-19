using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRandomizer : MonoBehaviour
{
    [SerializeField] private Mesh[] _meshes;
    private MeshFilter _meshFilter;

    void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    private void Start()
    {
        if (_meshes.Length > 0)
        {
            int randomIndex = Random.Range(0, _meshes.Length);
            _meshFilter.mesh = _meshes[randomIndex];
        }
    }
}
