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
    private float scaleFactor = 0.45f;
    private float topWalkSpeed = 2.5f;
    private float time;
    private bool toggle = true;
    private GameObject gear;


    void Start()
    {
        _player = GameObject.Find("/Player");
        _playerRigid = GetComponent<Rigidbody>();
        _controllerTemp = GameObject.Find("Player/[CameraRig]/Controller (left)");
        _controller = _controllerTemp.GetComponent<SteamVR_TrackedController>();
        _controllerTransform = _controller.GetComponent<Transform>();
        gear = GameObject.FindWithTag("FJG");
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
                accelerate = false;
            }

            if (Mathf.Abs(_playerRigid.velocity.z) > topWalkSpeed)
            {
                accelerate = false;
            }

            if (accelerate)
            {
                projection = new Vector3(_controllerTransform.forward.x * scaleFactor, 0, _controllerTransform.forward.z * scaleFactor);
                _playerRigid.AddForce(projection, ForceMode.Impulse);
            }

            if(_controller.padPressed && toggle && gear.GetComponent<MeshRenderer>().enabled == true)
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
