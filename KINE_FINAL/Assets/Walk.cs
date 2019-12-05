using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _controllerTemp;
    private SteamVR_TrackedController _controller;
    private Transform _controllerTransform;
    private GameObject _player;
    private Rigidbody _playerRigid;
    private Vector3 projection;
    private float scaleFactor = 0.35f;
    private float topWalkSpeed = 2.5f;
    private float time;
    private bool toggle = true;


    void Start()
    {
        _player = GameObject.Find("/Player");
        _playerRigid = GetComponent<Rigidbody>();
        _controllerTemp = GameObject.Find("Player/[CameraRig]/Controller (left)");
        _controller = _controllerTemp.GetComponent<SteamVR_TrackedController>();
        _controllerTransform = _controller.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        _controllerTemp = GameObject.Find("Player/[CameraRig]/Controller (left)");
        _controller = _controllerTemp.GetComponent<SteamVR_TrackedController>();
        _controllerTransform = _controller.GetComponent<Transform>();

        if (_controller.padTouched)
        {
            float yRot = _controllerTransform.eulerAngles.y;
            bool accelerate = true;

            if (Mathf.Abs(_playerRigid.velocity.x) > topWalkSpeed)
            {
                if(_playerRigid.velocity.x < 0)
                    projection = new Vector3(-topWalkSpeed, _playerRigid.velocity.y, _playerRigid.velocity.z);
                else
                    projection = new Vector3(topWalkSpeed, _playerRigid.velocity.y, _playerRigid.velocity.z);

                _playerRigid.velocity = projection;
                accelerate = false;
            }

            if (Mathf.Abs(_playerRigid.velocity.z) > topWalkSpeed)
            {
                if (_playerRigid.velocity.z < 0)
                    projection = new Vector3(_playerRigid.velocity.x, _playerRigid.velocity.y, -topWalkSpeed);
                else
                    projection = new Vector3(_playerRigid.velocity.x, _playerRigid.velocity.y, topWalkSpeed);

                _playerRigid.velocity = projection;
                accelerate = false;
            }

            if (accelerate)
            {
                projection = new Vector3(_controllerTransform.forward.x * scaleFactor, 0, _controllerTransform.forward.z * scaleFactor);
                _playerRigid.AddForce(projection, ForceMode.Impulse);
            }

            if(_controller.padPressed && toggle)
            {
                projection = new Vector3(0, 7.5f, 0);
                _playerRigid.AddForce(projection, ForceMode.Impulse);
                toggle = false;
                time = Time.timeSinceLevelLoad;
            }

            if (!_controller.padPressed && !toggle && Time.timeSinceLevelLoad - time > 2f)
                toggle = true;
        }
    }
}
