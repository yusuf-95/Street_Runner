using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float jump = 4.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    public Rigidbody PlayerRB;

    public AudioClip[] PlayerSounds;

    // Use this for initialization
    void Start () {

        controller = GetComponent<CharacterController>();
        PlayerRB = GetComponent<Rigidbody>();
        moveVector = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

        Move();

        if (Enemy.GameOver == true)
            Stop();   
	}

    void Move()
    {

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jump;
                PlaySound(0);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveVector.x = Input.GetAxis("Horizontal") * speed;

        moveVector.y = verticalVelocity;

        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

        if(speed != 0)
        {
            PlaySoundWalking(1);
        }
    }

    void Stop()
    {
        speed = 0;
        jump = 0;
    }

    void PlaySound(int clip)
    {
        AudioSource au = GetComponent<AudioSource>();
        au.clip = PlayerSounds[clip];
        au.Play();
    }

    void PlaySoundWalking(int clip)
    {
        AudioSource au = GetComponent<AudioSource>();
        if (!au.isPlaying)
        {
            au.clip = PlayerSounds[clip];
            au.Play();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "stageEnd")
        {
            SceneManager.LoadScene("Stage2");
        }

        if(col.tag == "stageEnd2")
        {
            SceneManager.LoadScene("SplashScreen");
        }
    }
}
