using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSTest : MonoBehaviour
{
    public float speed = 5.0f;
    public float DestFov= 50.0f;
    public 
    // Start is called before the first frame update
    void Start()
    {
        //fov = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2")) {
            //Debug.Log("ADS");
            Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, DestFov, Time.deltaTime * speed);
        }
        if(Input.GetButtonUp("Fire2")) {
            Camera.main.fieldOfView = 60;
        }
    }
}
