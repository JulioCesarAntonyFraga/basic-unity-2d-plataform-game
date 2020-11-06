using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public int damage = 30;
    public float attackRange = 0.5f;
    private bool allowAttack = true;
    public float fireRate = 0.15f;
    public float meleeVolume;

    CharacterController2D player;

    public LayerMask enemyLayers;
    public Transform attackPoint;
    public Animator animator;

    public AudioClip[] meleeSound; //So the shots don't sound the same every time
    private AudioSource m_AudioSource; //The thing to play the audio


    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

        if (m_AudioSource == null)
        {
            Debug.LogError("No AudioSource found");
        }

    }

    void PlayMeleeSound()
    {

        m_AudioSource.clip = meleeSound[0];

        //volume
        m_AudioSource.volume = meleeVolume;

        //Play the sound once
        m_AudioSource.PlayOneShot(m_AudioSource.clip);

    }


    // Update is called once per frame
    void Update()
    {

        player = GetComponent<CharacterController2D>();

        if (Input.GetKeyDown(KeyCode.C) && allowAttack && player.m_Grounded == true)
        {

            StartCoroutine(Attack());

        }

    }

    IEnumerator Attack()
    {

        allowAttack = false;


        animator.SetTrigger("Attack");

        PlayMeleeSound(); //Play a melee sound

        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {

            enemy.GetComponent<EnemyDamage>().TakeDamage(damage);

        }


        yield return new WaitForSeconds(fireRate);

        allowAttack = true;

    }

    private void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

}
