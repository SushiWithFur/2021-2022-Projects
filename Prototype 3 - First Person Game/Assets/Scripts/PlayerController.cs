using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance 
    {
        get;
        set;
    }
    //movement
    public float moveSpeed;
    public float jumpForce;
    //camera
    public float lookSensitivity; //mouse look sensitivity
    public float maxLookX; // lowest down position we can look
    public float minLookX; // highest up position we can look
    private float rotX; //current X rotation of the camera
    [Header("Game Objects and Componenets")]
    private Camera cam;
    private Rigidbody rb;
    private Weapon weapon;
    public bool isOnGround;
    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int deathcount;
    public GameUI health;
    public GameOver gameOver;

    void Awake() 
    {
        //Get the components
        cam = Camera.main;   
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        deathcount = 0;
        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        //initialize the UI
        health.ChangeHealth(5);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0)
        {
            Die();
        }

        health.ChangeHealth(curHP);
        
    }
    void Die()
    {
        gameOver.gameOver();
        SceneManager.LoadScene("Game Over");

    }
    // Update is called once per frame
    void Update()
    {
        //Don't do anything while game paused
        if(GameManager.instance.gamePaused == true)
        {
            return;
        }

        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
         Jump();
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
    }
    void Move()
    {
        if(Input.GetKey("left shift"))
        {
            moveSpeed = 10f;
        }
        else
        {
            if(isOnGround == true)
            {
                moveSpeed = 5f;
            }
        }
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //face the direction of the camera
        Vector3 dir = transform.right * x + transform.forward * z;
        //jump direction
        dir.y = rb.velocity.y;
        //move in the direction of the camera
        rb.velocity = dir;

    }
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX  += Input.GetAxis("Mouse Y") * lookSensitivity;
        // clamps camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        // apply rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("DeathPlane"))
            curHP = 0;
    }
    public void GiveHealth (int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo (int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
}
