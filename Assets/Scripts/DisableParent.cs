using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
