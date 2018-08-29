using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    public float s = .02f;
    public int i = 0;
    bool increment = true;
    // Use this for initialization
    void Start () {
        init();
	}

    // Update is called once per frame
    void Update()
    {
        i++;
        int j = i / 50;
        if (j % 2 == 0)
            transform.Rotate(0, 0, -10 * Time.deltaTime);
        else
            transform.Rotate(0, 0, 10 * Time.deltaTime);
        //transform.Translate(0, 0, s);
         //...also rotate around the World's Y axis
       // transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
        //    if (increment)
        //    {
        //        print("increment" + transform.eulerAngles);
        //        transform.Rotate(0, 0, 10*Time.deltaTime);
        //        if (transform.eulerAngles.z >= 30)
        //        {
        //            increment = false;
        //            //print("localRotation greater than 30");
        //        }

        //    }
        //    else
        //    {
        //        transform.Rotate(0, 0, -10*Time.deltaTime);
        //        if (transform.eulerAngles.z >= 330)
        //            increment = true;
        //    }
    }

    void init()
    {
        increment = true;

    }
}

