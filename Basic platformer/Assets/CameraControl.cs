using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// LateUpdate is called after every frame
	void LateUpdate () {
        float maxX = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float maxY = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(maxX, maxY, gameObject.transform.position.z);
    }
}
