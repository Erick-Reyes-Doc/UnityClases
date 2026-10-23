
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    public float velocidad = 6f;

    private Rigidbody2D rb;
    private bool juegoIniciado = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // La pelota espera sobre Player
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.simulated = false;
    }

    void Update()
    {
        if (!juegoIniciado &&
            Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            LanzarPelota();
        }
    }

    void LanzarPelota()
    {
        juegoIniciado = true;

        // La pelota deja de ser hija de Player
        transform.SetParent(null, true);

        // Activamos nuevamente las fisicas
        rb.simulated = true;

        // Lanzamos la pelota
        Vector2 direccion = new Vector2(1f, 1f).normalized;

        rb.linearVelocity = direccion * velocidad;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float diferencia = transform.position.x -
                               collision.transform.position.x;

            Vector2 direccion =
                new Vector2(diferencia, 1f).normalized;

            rb.linearVelocity = direccion * velocidad;
        }
    }
}
