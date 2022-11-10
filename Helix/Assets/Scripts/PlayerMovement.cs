using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public float speed = 5f;
    public Rigidbody rb;
    public Animator anim;
    public ParticleSystem particle;
    public ParticleSystem particle_speed;

    //public int 

    bool isTouching;
    public bool isAlive;
    float touchPosX;
    Vector3 direction;

    float horizontalInput;
    float horizontalMultiplier = 2f;

    float axisX = 0;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    private void FixedUpdate()
    {
        axisX = 0;
        if (GameManager.instance.startGame)
        {
            anim.SetBool("startGame", true);
            particle.Play();
            particle_speed.Play();
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * GameManager.instance.controlAxis * (speed / 2)  * Time.fixedDeltaTime * horizontalMultiplier;

            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        } else
        {
            if (isAlive)
                anim.SetBool("startGame", false);
            else 
                anim.SetBool("isAlive", false);
            particle.Stop();
            particle_speed.Stop();
        }
    }
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerDeath()
    {
        isAlive = false;
        GameManager.instance.startGame = false;
        GameManager.instance.UI.SetActive(false);

        StartCoroutine(DisplayUI());
    }

    IEnumerator DisplayUI()
    {
        yield return new WaitForSeconds(3f);

        GameManager.instance.Defeated.SetActive(true);
    }
}
