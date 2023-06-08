using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCode : MonoBehaviour
{

    LineRenderer lineRenderer;

    public Transform origin;
    public Transform destination;

    public GameObject[] handPoints;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;


        //THE CODE: 
        string[] pointIndexes = gameObject.name.Split(' ')[1].Split('-');
        //origin = GameObject.Find($"Point ({pointIndexes[0]})").transform;
        //destination = GameObject.Find($"Point ({pointIndexes[1]})").transform;

        handPoints = GameObject.Find($"Manager").GetComponent<HandTracking>().handPoints;
        origin = handPoints[int.Parse(pointIndexes[0])].transform;
        destination = handPoints[int.Parse(pointIndexes[1])].transform;
        

    }

    // Update is called once per frame
    void Update()
    {
        print("origin.localPosition = " + origin.localPosition);
        lineRenderer.SetPosition(0, origin.localPosition); // 0 => starting point
        lineRenderer.SetPosition(1, destination.localPosition); // 1 => ending point
        //transform.localScale = handPoints[0].transform.localScale;
    }
}

/* ORIGINAL
public class LineCode : MonoBehaviour
{

    LineRenderer lineRenderer;

    public Transform origin;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
    }
}
*/