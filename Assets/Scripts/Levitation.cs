using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitation : MonoBehaviour {

    public float verticalSpeed;
    public float amplitude;

    void Update()
    {
        transform.position = transform.position + new Vector3(0, Mathf.Sin(verticalSpeed * Time.realtimeSinceStartup) * amplitude, 0);
    }
}
