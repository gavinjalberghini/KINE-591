using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject prefab;
    private SteamVR_TrackedController _controller;
    private Transform _controllerTransform;
    private bool toggle = true;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        //prefab = Resources.Load("Projectile") as GameObject;
        _controller = GetComponent<SteamVR_TrackedController>();
        _controllerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (_controller.triggerPressed && toggle)
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = _controllerTransform.position + _controllerTransform.transform.forward / 4;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = _controller.transform.forward * 40;
            time = Time.timeSinceLevelLoad;
            toggle = false;
        }
        
        if(!_controller.triggerPressed && !toggle)
        {
            toggle = true;
        }
    }
}
