using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeout : MonoBehaviour
{

    float spawn_time;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        spawn_time = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad - spawn_time;

        if(time > 45f)
        {
            Destroy(gameObject);
        }
    }
}
