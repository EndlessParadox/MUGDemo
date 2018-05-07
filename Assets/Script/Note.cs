using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public TweenPosition pTP;

	// Use this for initialization
	void Start () {
        pTP.SetOnFinished(SelfDestroy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
