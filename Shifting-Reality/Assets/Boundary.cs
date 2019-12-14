using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _playerRigid;
    private Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("/Player");
        _playerRigid = _player.GetComponent<Rigidbody>();
        _playerTransform = _player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerTransform.position.y < -50)
        {
            Vector3 reset_vector = new Vector3(-_playerTransform.position.x, -_playerTransform.position.y, -_playerTransform.position.z);
            _playerTransform.Translate(reset_vector, Space.World);
        }
    }
}
