using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class SwordScript : MonoBehaviour
{

    private Animator anim;
    private bool canSwing = true; // Player can swing again after animation is finished

    private VolumeManager AM;

    public bool hasSword = false; // Player has picked up the sword

    private bool isAttacking = false;

    [SerializeField] private GameObject hitParticle;

    public bool enemyCanGetHit = true; // When the enemy gets hit this goes false until the EnemyHit animation is finished

    [SerializeField] private int defeatedEnemies;

    [SerializeField] private GameObject winScreen;

    [SerializeField] private GameObject objectives;

    void Start()
    {
        AM = VolumeManager.Instance;
        anim = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && isAttacking && enemyCanGetHit)
        {
            AM.GetComponent<VolumeManager>().boneHitAudio();
            if(other.GetComponent<EnemyScript>().enemyHealth == 1)
            {
                other.tag = "Untagged";
                other.GetComponent<Animator>().SetTrigger("Death");
                other.GetComponent<NavMeshAgent>().enabled = false;
                other.GetComponent<EnemyScript>().enabled = false;
            }
            else
            {
                other.GetComponent<EnemyScript>().enemyHealth--;
                other.GetComponent<Animator>().SetTrigger("Hit");
                other.GetComponent<NavMeshAgent>().isStopped = true;
                enemyCanGetHit = false; // So the enemy can't get hit multiple times during 1 attack
            }
            // I made a particle spawn thing here, but I could not find the right particle and moved on to other priorities.
            //Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }    

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (canSwing && hasSword && Time.timeScale == 1f)
        {
            isAttacking = true;
            anim.enabled = true;
            anim.SetTrigger("isSwinging");
            AM.GetComponent<VolumeManager>().swordSwingAudio();
            // Add a sword swing audio SFX here in the future
            canSwing = false;
        }
    }

    public void ReadyToAttack()
    {
        // Animation event that will run this after the SwordSwing animation is done
        canSwing = true;
        isAttacking = false;
    }

    public void AndAnotherOneBitesTheDust()
    {
        defeatedEnemies++;
        if (defeatedEnemies == 2)
        {
            // Win Screen
            AM.GetComponent<VolumeManager>().musicClip.volume = 0f;
            AM.GetComponent<VolumeManager>().playerWinAudio();
            objectives.SetActive(false);
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}
