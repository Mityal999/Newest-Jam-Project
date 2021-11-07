using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public GameObject deathcanvas;
    public PlayerAttackItem attackItem;
    public Transform respawnTransform;
    private CharacterController characterController;
    private JumpSoundSystem jumpSoundSystem;
    private HealthBar healthBar;

    public ShuffledSoundPlayer getHitSoundPlayer;
    public ShuffledSoundPlayer dieSoundPlayer;

    public float regenHp;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        jumpSoundSystem = GetComponent<JumpSoundSystem>();
        healthBar = FindObjectOfType<HealthBar>();
        currentHp = initialHp;

        healthBar.SetMaxHealth(initialHp);
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical")   +   transform.right * Input.GetAxis("Horizontal");
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                jumpSoundSystem.PlayJumpSound();
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);




        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = - verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);



        if (Input.GetMouseButtonDown(0))
        {
            attackItem.TryAttack();
        }
    }


    private void FixedUpdate()
    {
        if (currentHp < initialHp)
        {
            currentHp += regenHp;
            healthBar.SetHealth(currentHp);
        }
            
    }



    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon")
        {
            EnemyAttackItem attackItem = other.gameObject.GetComponentInParent<EnemyAttackItem>();
            float damageToRecieve = attackItem.GetCurrentDamage();
            TryRecieveDamage(damageToRecieve);
        }
    }

    public override void OnDamageRecieved(float damage)
    {
        getHitSoundPlayer.PlayOnce();
        healthBar.SetHealth(currentHp);
    }

    public override void Die()
    {
        dieSoundPlayer.PlayOnce();
        deathcanvas.SetActive(true);
        healthBar.gameObject.SetActive(false);
    }
    public void Respawn()
    {
        characterController.enabled = false;
        currentHp = initialHp;
        transform.position = respawnTransform.position;
        characterController.enabled = true;
    }
}
