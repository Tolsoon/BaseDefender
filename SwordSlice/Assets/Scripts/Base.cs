using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    private Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBaseHealth();
    }


    void UpdateBaseHealth()
    {        
        Color tempColor = material.color;
        tempColor.a = curHealth/maxHealth;
        material.color = tempColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            curHealth -= collision.gameObject.GetComponent<Enemy>().damage;
        }
    }
}
