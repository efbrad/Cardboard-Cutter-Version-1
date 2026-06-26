using System.Collections;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    public float WaitTimeForAttacks = 3f;

    EnemyController controller;
    bool attacking;

    private void Start()
    {
        controller = GetComponent<EnemyController>();
    }

    private void FixedUpdate()
    {
        if(controller.state == EnemyState.Standing && !attacking)
        {
            StartCoroutine(WaitAndAttack());
        }
    }

    IEnumerator WaitAndAttack()
    {
        attacking = true;
        yield return new WaitForSeconds(WaitTimeForAttacks);
        if(controller.state == EnemyState.Standing)
        {
            Attack();
        }
        attacking = false;
    }

    void Attack()
    {
        Debug.Log("Attacked player");
    }
}
