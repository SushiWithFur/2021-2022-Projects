using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackObj;
    public GameObject Player;
    public Animator animator;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        attackObj.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void startPlayerAttack()
    {
        attackObj.SetActive(true);
        StartCoroutine(playerAttack());
    }

    public IEnumerator playerAttack()
    {
        animator.SetBool("IsAttacking",true);
        yield return new WaitForSeconds(0.35f);
        animator.SetBool("IsAttacking", false);
        attackObj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
