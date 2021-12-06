using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyTwo : MonoBehaviour
{

    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int scoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;
    
    private List<Vector3> path;

    private Weapon weapon;
    private GameObject target;

    private bool chaseTarget;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
        curHP = maxHP;
        //Gather Components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    void UpdatePath()
    {
        //Calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        //Save path as a list
        path = navMeshPath.corners.ToList();
    }

    IEnumerator waiter()
    {
        if(chaseTarget = true)
        {
             yield return new WaitForSeconds(10);
             transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z + 3);
        }
    }
    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        //look at target
        Vector3 dir =(target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;
        //get distance from enemy to player tartget
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if(dist <= attackRange)
        {
            chaseTarget = false;
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            } 
        }
        else
            {
                chaseTarget = true;
            }
    }
}
