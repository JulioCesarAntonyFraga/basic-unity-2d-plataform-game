using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingLeft = true;

    public LayerMask scenario;

    public Transform groundDetection;
    public Transform wallDetection;

    private void Update()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down, distance);

        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, wallDetection.right, distance);


        if (groundInfo.collider == false || wallInfo.transform.name == "Tilemap")
        {

            if (movingLeft)
            {

                transform.Rotate(0f, 180f, 0f);
                movingLeft = false;

            }
            else
            {

                transform.Rotate(0f, 0f, 0f);
                movingLeft = true;

            }

        }

    }

}
