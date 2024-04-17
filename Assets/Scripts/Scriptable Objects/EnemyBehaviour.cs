using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

public class EnemyBehaviour : ScriptableObject
{
    public string enemyName;
    public string enemyDescription;

    public int setEnemyHealth;
}
