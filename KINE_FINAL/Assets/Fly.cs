using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    // Start is called before the first frame update
    private SteamVR_TrackedController _controller;
    private Transform _controllerTransform;
    private GameObject _player;
    private Rigidbody _playerRigid;
    private Transform _playerTransform;
    private GameObject _headset;
    private Transform _headsetTransform;
    private double scaleFactor = 0.15;

    void Start()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controllerTransform = GetComponent<Transform>();
        _player = GameObject.Find("/Player");
        _playerRigid = _player.GetComponent<Rigidbody>();
        _playerTransform = _player.GetComponent<Transform>();
        _headset = GameObject.FindWithTag("MainCamera");
        _headsetTransform = _headset.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controller.padPressed)
        {
            Vector3 projection = calcXYZDir(_controllerTransform.position.x, _controllerTransform.position.y, _controllerTransform.position.z, _headsetTransform.position.x, _headsetTransform.position.y, _headsetTransform.position.z);
            _playerRigid.AddForce(projection, ForceMode.Impulse);
        }
    }

    Vector3 calcXYZDir(float xC, float yC, float zC, float xP, float yP, float zP)
    {
        float x = -1 * (xC - xP) * (float)(scaleFactor);
        float y = -1 * (yC - yP) * (float)(scaleFactor);
        float z = -1 * (zC - zP) * (float)(scaleFactor);

        return new Vector3(x, y, z);
    }
}
