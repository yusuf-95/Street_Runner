using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

    public Rigidbody Barrelrb;
    public GameObject Barrel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(Barrel.transform.position.x <= -2)
            Barrelrb.AddForce(5, 0, 0, ForceMode.Impulse);

        if(Barrel.transform.position.x >= 2)
            Barrelrb.AddForce(-5, 0, 0, ForceMode.Impulse);

    }
}
