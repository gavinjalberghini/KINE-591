using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{

    private string tag = "";
    GameObject gear;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION ENTER");

        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Right" || other.gameObject.tag == "Left")
        {
            tag = gameObject.tag;

            if(tag == "JG")
            {
                gear = GameObject.FindWithTag("FJG");
                gear.GetComponent<MeshRenderer>().enabled = true;

            } else if (tag == "IG")
            {
                gear = GameObject.FindWithTag("FIG");
                gear.GetComponent<MeshRenderer>().enabled = true;
            } else if (tag == "FG")
            {
                gear = GameObject.FindWithTag("FFG");
                gear.GetComponent<MeshRenderer>().enabled = true;
            } else if (tag == "SG")
            {
                gear = GameObject.FindWithTag("FSG");
                gear.GetComponent<MeshRenderer>().enabled = true;
            } else if (tag == "ZGG")
            {
                gear = GameObject.FindWithTag("FZGG");
                gear.GetComponent<MeshRenderer>().enabled = true;
            }
            else if (tag == "SIG")
            {
                gear = GameObject.FindWithTag("FSIG");
                gear.GetComponent<MeshRenderer>().enabled = true;
            }

            gameObject.active = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("COLLISION EXIT");
    }
}
