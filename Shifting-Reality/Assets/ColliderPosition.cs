using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPosition : MonoBehaviour
{

    CapsuleCollider _playerCol;
    private GameObject _headset;
    private Transform _headsetTransform;


    // Start is called before the first frame update
    void Start()
    {
        _headset = GameObject.FindWithTag("MainCamera");
        _headsetTransform = _headset.GetComponent<Transform>();
        _playerCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
