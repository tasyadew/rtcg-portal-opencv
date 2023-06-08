using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    public GameObject scalePoints;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        if (data.Length == 0)
            return;
        
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        

        print(data);
        string[] points = data.Split(',');
        print(points[0]);

        //0        1*3      2*3
        //x1,y1,z1,x2,y2,z2,x3,y3,z3

        Vector3 camPos = Camera.main.transform.position;
        Quaternion camRot = Camera.main.transform.rotation;
        print("camPos = " + camPos + " | camRot = " + camRot);
        for (int i = 0; i < 21; i++)
        {

            float x = (float.Parse(points[i * 3]) / 100);
            float y = (float.Parse(points[i * 3 + 1]) / 100);
            float z = (float.Parse(points[i * 3 + 2]) / 100);

            handPoints[i].transform.localPosition = new Vector3(x, y, z);

        }
        

        //float f = (d*w)/W;
        float w = Vector3.Distance(handPoints[5].transform.localPosition, handPoints[0].transform.localPosition);
        float W = 2.5f;
        float f = 5;
        float d = (W * f) / w;

        float scaleConstant = 1.0f;
        float scaleFactor = 1.5f;
        //1 = 1.5
        float newScale = (scaleConstant * w) / scaleFactor;
        // 1 = (1*1.5) / 1l5
        print("d = " + d);
        
        for (int i = 0; i < 21; i++)
        {
            float x2 = handPoints[i].transform.localPosition[0];
            float y2 = handPoints[i].transform.localPosition[1];
            float z2 = handPoints[i].transform.localPosition[2] + d;

            handPoints[i].transform.localPosition = new Vector3(x2, y2, z2);
            //scalePoints.transform.localScale = new Vector3(d/7, d/7, d/7);
        }
        



    }
}