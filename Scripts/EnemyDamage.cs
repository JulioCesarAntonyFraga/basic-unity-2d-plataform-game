﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int health = 100;
    public float punchVolume;

    public GameObject deathEffect;
    private Animator animator;

    public AudioClip[] m_PunchSound; //So the shots don't sound the same every time
    private AudioSource m_AudioSource; //The thing to play the audio

    private void Start()
    {
        animator = GetComponent<Animator>();

        m_AudioSource = GetComponent<AudioSource>();

        if (m_AudioSource == null)
        {
            Debug.LogError("No AudioSource found");
        }
    }

    void PlayPunchSound()
    {

        m_AudioSource.clip = m_PunchSound[0];

        //Volume
        m_AudioSource.volume = punchVolume;

        //Play the sound once
        m_AudioSource.PlayOneShot(m_AudioSource.clip);

    }

    public void TakeDamage (int damage)
    {

        health -= damage;

        animator.SetTrigger("Hurt");

        PlayPunchSound();

        if (health <= 0)
        {

            Die();

        }

    }

    void Die()
    {
        PlayPunchSound();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
