using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

    public Rigidbody Barrelrb;
    public GameObject Barrel;
    private Transform playerTransform;
    public static bool barrelRoll = false;

    // Use this for initialization
    void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerTransform.position.z >= Barrel.transform.position.z - 11)
        {
            Barrelrb.AddForce(1, 0, 0, ForceMode.Impulse);
            Barrelrb.constraints = RigidbodyConstraints.None;
            barrelRoll = true;
        }

        if (playerTransform.position.z >= Barrel.transform.position.z)
        {
            barrelRoll = false;
        }
    }
}
