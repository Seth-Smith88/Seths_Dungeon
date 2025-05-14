using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform player;
    private Animator _animator;
    public float speed = 2f;
    public float moveDistance = 3f;

    private Vector2 startPos;
    private bool movingRight = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
        
        startPos = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= startPos.x + moveDistance)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= startPos.x - moveDistance)
            {
                movingRight = true;
                Flip();
            }

            {
                if (player == null) return; // Exit if no player assigned


                // Calculate the direction towards the player
                Vector3 direction = (player.position - transform.position).normalized;
                _animator.enabled = true;

                // Move the enemy towards the player
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    void Flip()
    {
        // Flip the enemy's sprite direction
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}