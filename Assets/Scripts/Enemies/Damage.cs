using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int health = 100;
    public GameObject takeDamage;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnDamage(25);
        }
    }
    public void OnDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            animator.SetBool("isDead", true);
            Invoke(nameof(Destroy), 10);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
