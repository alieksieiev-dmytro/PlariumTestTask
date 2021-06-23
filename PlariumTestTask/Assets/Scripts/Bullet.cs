using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public int range = 10;

    public Team Team { get; set; }
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, startingPosition) < range)
        {
            transform.Translate(new Vector3(0, 1) * Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //TODO: React to target
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBase>() != null && this.Team == Team.BlueTeam)
        {
            collision.SendMessage("Damage", damage);
        }

        Destroy(gameObject);
    }
}
