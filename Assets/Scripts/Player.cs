using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text healthDisplay;
    public float speed;
    private float input;
    public GameObject losePanel;

    Rigidbody2D rb;
    Animator anim;
    AudioSource source;
    public int health;
    // Use this for initialization
    //This is used to get the components we apply to our object and the info stored in it.
    void Start () {
        healthDisplay.text = health.ToString();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        
	}

    //This is used to deal with the non physics part like transitioning our animations.
    private void Update()
    {
        if(input!=0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    // Update is called once per frame
    // This is for the physics part where we  move the object left anr right.
    void FixedUpdate() {
        input = Input.GetAxisRaw("Horizontal");
        //print(input);
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
	}

    public void TakeDamage(int damagaeAmount)
    {
        source.Play();
        health -= damagaeAmount;
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
