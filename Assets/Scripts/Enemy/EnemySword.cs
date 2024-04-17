using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && enemy.GetComponent<EnemyScript>().enemyIsAttacking && enemy.GetComponent<EnemyScript>().playerCanGetHit && enemy.GetComponent<EnemyScript>().enemyWindUpDone)
        {
            enemy.GetComponent<EnemyScript>().PlayerIsHit();
            enemy.GetComponent<EnemyScript>().playerCanGetHit = false;
        }
    }
}
