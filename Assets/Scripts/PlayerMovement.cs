using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 8f;

    private Rigidbody2D rb;
    private Vector2 movimiento = Vector2.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        // Izquierda
        if (Keyboard.current.aKey.wasPressedThisFrame ||
            Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            movimiento = Vector2.left;
        }

        // Derecha
        if (Keyboard.current.dKey.wasPressedThisFrame ||
            Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            movimiento = Vector2.right;
        }

        // Arriba
        if (Keyboard.current.wKey.wasPressedThisFrame ||
            Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            movimiento = Vector2.up;
        }

        // Abajo
        if (Keyboard.current.sKey.wasPressedThisFrame ||
            Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            movimiento = Vector2.down;
        }

        // Detener con espacio
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            movimiento = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movimiento * velocidad;
    }
}