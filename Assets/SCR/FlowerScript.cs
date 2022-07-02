using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Vector3 start, end;

    public LayerMask playerLayer;
    private bool isUp;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }

        player = GameObject.FindGameObjectWithTag("player");

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position)
        {
            StartCoroutine("DirectionChange");
        }

    }

    private IEnumerator DirectionChange()
    {
        yield return new WaitForSeconds(2f);
        target.position = (target.position == start) ? end : start;
        StopCoroutine("DirectionChange");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            if (PlayerController.growUp)
            {
                if(PlayerController.isFlowerUp)
                {
                    PlayerController.isFlowerUp = false;
                }

                PlayerController.growUp = false;
            }
            else
            {
                PlayerController.death = true;
            }
        }
    }
}