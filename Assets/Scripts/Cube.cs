using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float yPos;
    private float zPos;

    // Start is called before the first frame update
    void Start()
    {
        yPos = Mathf.Clamp(transform.position.y, -10f, 5f);
        zPos = Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z + 5);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
