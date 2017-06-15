using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public GameObject EnemyChase;
    private Transform playerTransform;
    public Animator Hit;
    public int EnemySpeed;

    public static bool GameOver = false;

    public AudioClip[] EnemySounds;

    // Use this for initialization
    void Start()
    {

        playerTransform = GameObject.FindGameObjectWithTag("PFP").transform;
        Hit = GetComponent<Animator>();

        

    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        if (GameOver == true)
            Invoke("Load", 0.6f);
    }

    void FollowPlayer()
    {
        transform.LookAt(playerTransform);

        //if (transform.position.z <= playerTransform.position.z - 10)
        //    EnemySpeed = 8;
        //if (transform.position.z < playerTransform.position.z - 1.5)
        //    EnemySpeed = 5;

        if (Vector3.Distance(transform.position, playerTransform.position) > 1.5)
        {
            transform.position += transform.forward * EnemySpeed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, playerTransform.position) <= 1.5)
        {
            Hit.Play("Hit");
            GameOver = true;
            EnemySpeed = 0;
            PlaySound(0);
        }
    }

    void Load()
    {
            SceneManager.LoadScene("MainMenu");
    }


    void PlaySound(int clip)
    {
        AudioSource au = GetComponent<AudioSource>();
        if (!au.isPlaying)
        {
            au.clip = EnemySounds[clip];
            au.PlayDelayed(0.4f);
        }
    }

}  
