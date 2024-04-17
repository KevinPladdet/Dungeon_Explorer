using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    [SerializeField] private GameObject sword;

    public void WaitForDeathAnim()
    {
        // This method is an animation event that start after the enemy death animation is finished
        sword.GetComponent<SwordScript>().AndAnotherOneBitesTheDust();
    }
}
