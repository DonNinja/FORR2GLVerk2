using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseMeUp : MonoBehaviour {

    public GameObject Lyfta;

    public float moveSpeed;

    public Transform stadur;

    public Transform[] stodur;

    public int stoduVal;

	// Use this for initialization
	void Start () {
        stadur = stodur[stoduVal]; //Setur current position sem position 1 í lykkjunni
	}
	
	// Update is called once per frame
	void Update () {
        Lyfta.transform.position = Vector3.MoveTowards(Lyfta.transform.position, stadur.position, Time.deltaTime * moveSpeed); //færir Lyfta að nýju position

        if (Lyfta.transform.position == stadur.position)
        {
            stoduVal++;

            if (stoduVal == stodur.Length)
            {
                stoduVal = 0;
            }

            stadur = stodur[stoduVal];
        }
	}
}
