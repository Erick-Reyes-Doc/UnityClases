using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad = 5f;
    public Vector2 direccion = Vector2.right;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        direccion = direccion.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direccion * velocidad;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;

        direccion = Vector2.Reflect(
            direccion,
            normal
        ).normalized;
    }
}