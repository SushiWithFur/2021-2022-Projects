using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float movementSpeed = 3;
    public float jumpForce = 3;
    public bool facingRight = true;

    public PlayerAttack attack;

    public bool firstHit;
    public int curHP;
    public int maxHP;
    private Rigidbody2D rb;
    public GameObject enemy;
    public bool enemyDirectionRight;
    public Health_Animation health;
    // Start is called before the first frame update
    void Start()
    {
        health.ChangeHealth(3);
        curHP = maxHP;
        firstHit = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        animator.SetFloat("Speed", Mathf.Abs(movement));
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {

            animator.SetBool("IsJumping", true);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (movement > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Attack") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            attack.startPlayerAttack();

            if (facingRight)
            {
                rb.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            }
            if (!facingRight)
            {
                rb.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
            }
            if (enemy.transform.position.x > transform.position.x)
            {
                enemyDirectionRight = true;
            }
            if (enemy.transform.position.x < transform.position.x)
            {
                enemyDirectionRight = false;
            }
        }
    }

    public void Hit(bool direction)
    {
        
        if (firstHit)
        {
            takeDamage(direction);
        }
    }
    public void takeDamage(bool direction)
    {
        if (Mathf.Abs(rb.velocity.y) > 0.001f)
        {
            animator.SetBool("IsHit", true);
        }

        firstHit = false;
        if (!direction)
        {
            curHP -= 1;
            health.ChangeHealth(curHP);
            rb.AddForce(Vector3.right * -7, ForceMode2D.Impulse);
            rb.AddForce(Vector3.up * 6, ForceMode2D.Impulse);

        }
        else
        {
            curHP -= 1;
            health.ChangeHealth(curHP);
            rb.AddForce(Vector3.left * -7, ForceMode2D.Impulse);
            rb.AddForce(Vector3.up * 6, ForceMode2D.Impulse);

        }
        if (curHP <= 0)
        {
            Die();
        }


    }


    void Die()
    {
        SceneManager.LoadScene("Game Over");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsHit", false);
        firstHit = true;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
