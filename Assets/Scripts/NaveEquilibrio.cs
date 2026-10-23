
using UnityEngine;

public class NaveEquilibrio : MonoBehaviour
{
    public float fuerza = 8f;

    private Rigidbody2D rb;
    private CambioColorPropulsor propulsor;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        propulsor =
            GetComponentInChildren<CambioColorPropulsor>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(
            horizontal,
            vertical
        );

        rb.AddForce(direccion * fuerza);

        CambiarColorSegunDireccion(horizontal, vertical);
    }

    void CambiarColorSegunDireccion(
        float horizontal,
        float vertical)
    {
        if (propulsor == null)
            return;

        if (vertical > 0)
        {
            propulsor.CambiarColor(Color.red);
        }
        else if (vertical < 0)
        {
            propulsor.CambiarColor(Color.yellow);
        }
        else if (horizontal != 0)
        {
            propulsor.CambiarColor(
                new Color(1f, 0.5f, 0f)
            );
        }
        else
        {
            propulsor.CambiarColor(Color.gray);
        }
    }
}
