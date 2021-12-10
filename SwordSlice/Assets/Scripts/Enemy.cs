using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;

    private Transform target;    
    void Start()
    {
        target = FindObjectOfType<Base>().gameObject.transform;        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MouseFollow>())
        {
            health -= collision.gameObject.GetComponent<MouseFollow>().damage;
        }

        if (collision.gameObject.GetComponent<Base>())
        {
            Destroy(gameObject);
        }
    }
}
