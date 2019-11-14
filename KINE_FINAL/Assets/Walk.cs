using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    // Start is called before the first frame update
    private SteamVR_TrackedController _controller;
    private Transform _controllerTransform;
    private GameObject _player;
    private Rigidbody _playerRigid;
    private int speed = 1;

    void Start()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controllerTransform = GetComponent<Transform>();
        _player = GameObject.Find("/Player");
        _playerRigid = _player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controller.padTouched)
        {
            float yRot = _controllerTransform.eulerAngles.y;
            Vector3 projection = new Vector3(_controllerTransform.forward.x, 0, _controllerTransform.forward.z);
            _playerRigid.velocity = projection;
        }
    }
}
