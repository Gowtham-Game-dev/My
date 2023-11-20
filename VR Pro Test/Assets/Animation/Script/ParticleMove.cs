using UnityEngine;

public class ParticleMove : MonoBehaviour

{ 
    public float moveSpeed = 5f;
    public float minY = -5f; // Minimum y-coordinate for targeting
    public float maxY = 5f; // Maximum y-coordinate for targeting

    private GameObject player;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ChooseRandomTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
    }

    void ChooseRandomTargetPosition()
    {
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + randomY, player.transform.position.z);
    }

    void MoveTowardsTarget()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Check if projectile reached target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            ChooseRandomTargetPosition();
        }
    }
}



