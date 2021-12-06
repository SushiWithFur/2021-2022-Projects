using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    public GameObject hitParticle;


    void OnEnable() 
    {
        shootTime = Time.time;  
    }
    void OnTriggerEnter(Collider other) 
    {
         //create the hit particle effect
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        //destroy hit particle
        Destroy(obj, 0.5f);
        //Did we hit the target aka player
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        else
            if(other.CompareTag("Enemy"))
                other.GetComponent<EnemyTwo>().TakeDamage(damage);
        //disable bullet
        gameObject.SetActive(false);
       
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }
}
