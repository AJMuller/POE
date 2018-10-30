using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public float zoomAmount = 10.6f;
    public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomAmount += 1;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoomAmount > 1)
            {
                zoomAmount -= 1;

            }

        }

        GetComponent<Camera>().orthographicSize = zoomAmount;

        if(Input.GetAxis("Mouse X")>0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime* speed,
            Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);
        }

        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
            Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);
        }




    }
}
