using UnityEngine;

public class EvilWizard : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;

    private Vector2 startPos;
    private bool _movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (_movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= startPos.x + moveDistance)
            {
                _movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= startPos.x - moveDistance)
            {
                _movingRight = true;
                Flip();
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