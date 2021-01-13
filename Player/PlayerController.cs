using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed;
    private float horizontal, vertical;

    private bool running;
    private bool equipped;
    private bool reEquip;

    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        animator = transform.GetComponent<Animator>();
        rb2d = transform.GetComponent<Rigidbody2D>();
    }

    private void Update() {

        if (gameManager.isScenePaused == false) {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            //Animate equip and run
            animator.SetBool("Equipped", (equipped));
            animator.SetBool("ReEquip", (reEquip));
            animator.SetBool("Running", (running));

            if (horizontal < 0) {
                spriteRenderer.flipX = true;
            } else spriteRenderer.flipX = false;

            if (horizontal != 0 || vertical != 0) {
                running = true;
            } else running = false;
        }
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        rb2d.AddForce(movement * speed);
    }
}