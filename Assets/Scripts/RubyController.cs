using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //Health
    public int maxHealth = 5;
    public float speed = 0.3f;
    public float timeInvincible = 2.0f;
    public int health { get { return currentHealth;}}
    int currentHealth;
    bool isInvincible;
    float invincibleTimer;
    
    //config of rigid body 
    new Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;

            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate(){
        Vector2 position = rigidbody2D.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        //transform.position = position;
        rigidbody2D.MovePosition(position);
    }

    public void ChangeHealth(int amount){

        if (amount < 0)
        {
            if(isInvincible)
                return;
                
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
