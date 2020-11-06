using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioClip[] m_GunShotSounds; //So the shots don't sound the same every time
    private AudioSource m_AudioSource; //The thing to play the audio

    public float fireRate = 0.5f;
    private bool allowFire = true;
    public float shootVolume;


    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

        if (m_AudioSource == null)
        {
            Debug.LogError("No AudioSource found");
        }
    }

    void PlayShootingSound()
    {

        m_AudioSource.clip = m_GunShotSounds[0];

        //volume
        m_AudioSource.volume = shootVolume;

        //Play the sound once
        m_AudioSource.PlayOneShot(m_AudioSource.clip);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && allowFire)
        {
            StartCoroutine(Shoot());
        }

    }

    IEnumerator Shoot()
    {

        allowFire = false;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        PlayShootingSound(); //Play a shooting sound

        yield return new WaitForSeconds(fireRate);

        allowFire = true;

    }

}
