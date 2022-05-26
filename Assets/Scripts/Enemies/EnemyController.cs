using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject enemy;
    int genHurt;
    public AudioSource[] hurtSound;
    public GameObject enemiesAI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            enemiesAI.SetActive(false);
            enemy.GetComponent<Animator>().Play("demo_combat_death");
            enemy.GetComponent<LookPlayer>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ammo")
        {
            currentHealth -= 20;
            genHurt = Random.Range(0, 3);
            hurtSound[genHurt].Play();
        }
    }
}
