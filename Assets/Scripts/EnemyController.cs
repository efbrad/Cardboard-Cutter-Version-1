using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public LayerMask PlayerLayer;
    public float DistanceFromPlayerStop;
    public EnemyState state;

    NavMeshAgent navMesh;
    GameObject player;
    

    private void Start()
    {
        player = GameObject.Find("Player");
        navMesh = GetComponent<NavMeshAgent>();
        state = EnemyState.Standing;
    }

    private void Update()
    {
        TestMove();
        Move();

        transform.LookAt(player.transform.position, Vector3.up);
    }


    void TestMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position, out hit, PlayerLayer))
        {
            if (hit.collider != null)
            {
                if(Vector3.Distance(transform.position, player.transform.position) < DistanceFromPlayerStop)
                {
                    state = EnemyState.Standing;
                    return;
                }
            }
        }

        state = EnemyState.Chasing;
    }

    void Move()
    {
        switch (state){
            case EnemyState.Standing:
                navMesh.SetDestination(transform.position);
                break;
            case EnemyState.Chasing:
                navMesh.SetDestination(player.transform.position);
                break;
        }
    }
}

public enum EnemyState
{
    Standing, Chasing
}
