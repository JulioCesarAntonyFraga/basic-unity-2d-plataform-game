using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    public int damage = 30;
    public float attackRange = 0.5f;
    private bool allowAttack = true;
    public float fireRate = 0.15f;
    public float meleeVolume;
    float minAttackRange = 1f;

    public Transform attackPoint;
    public Animator animator;
    public Transform playerPosition;

    public LayerMask playerLayer;


    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(playerPosition.position, gameObject.transform.position);

        if (distance < minAttackRange && allowAttack)
        {

            StartCoroutine(Attack());

        }

    }

    IEnumerator Attack()
    {

        allowAttack = false;


        animator.SetTrigger("Attack");


        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {

            player.GetComponent<Player>().TakeDamage(damage);

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
