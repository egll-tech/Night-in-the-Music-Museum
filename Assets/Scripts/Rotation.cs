using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float rotationSpeed;
    public string rotationAngle;

	void Update () {
        if (rotationAngle.Contains("up"))
            transform.Rotate(Vector3.up, rotationSpeed);
        else if (rotationAngle.Contains("forward"))
            transform.Rotate(Vector3.forward, rotationSpeed);
        else
            transform.Rotate(Vector3.right, rotationSpeed);
    }
}
