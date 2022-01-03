using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D enemyRb;
    public int unitsToMove = 4;
    public bool facingRight;
    public float enemySpeed = 3;
    private float startPos;
    private float endPos;
    public PlayerMovement playerMov;
    public bool moveRight = true;
    public float curHP;
    public float maxHP;
    public bool playerDirectionRight;
    public GameObject player;
    public bool firstHit;
    // Start is called before the first frame update
    public void Awake()
    {
        firstHit = true;
        curHP = maxHP;
        enemyRb = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = startPos + unitsToMove;
        facingRight = transform.localScale.x > 0;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 direction = (facingRight) ? transform.right : -transform.right;
        direction *= Time.deltaTime * enemySpeed;
        if (moveRight)
        {
            transform.Translate(direction);
            if (!facingRight)
            {
                Flip();
            }
        }
        if (enemyRb.position.x >= endPos)
        {
            moveRight = false;
        }
        if (!moveRight)
        {
            transform.Translate(direction);
            if (facingRight)
            {
                Flip();
            }
        }
        if (enemyRb.position.x <= startPos)
        {
            moveRight = true;
        }

        if (player.transform.position.x > transform.position.x)
        {
            playerDirectionRight = true;
        }
        if (player.transform.position.x < transform.position.x)
        {
            playerDirectionRight = false;
        }

        if (Mathf.Abs(enemyRb.velocity.y) > 0.001f)
        {
            animator.SetBool("Hit", true);
        }
    }
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = transform.localScale.x > 0;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetBool("Hit", false);
        firstHit = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMov.Hit(playerDirectionRight);
        }

        if (other.gameObject.tag == "PlayerAttack" && firstHit == true)
        {
            Hit();
        }
    }

    public void Hit()
    {

        takeDamage();
        firstHit = false;
        if (playerDirectionRight)
        {
            enemyRb.AddForce(Vector3.right * -7, ForceMode2D.Impulse);
            enemyRb.AddForce(Vector3.up * 6, ForceMode2D.Impulse);

        }
        else
        {
            enemyRb.AddForce(Vector3.left * -7, ForceMode2D.Impulse);
            enemyRb.AddForce(Vector3.up * 6, ForceMode2D.Impulse);

        }
        if (curHP <= 0)
        {
            Die();
        }


    }

    public void takeDamage()
    {

        curHP -= 1;

    }


    void Die()
    {
        Destroy(gameObject);
    }
}
