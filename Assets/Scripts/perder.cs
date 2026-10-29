using UnityEngine;
using UnityEngine.SceneManagement;

public class peredr : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos") ||
            collision.gameObject.CompareTag("Pared"))
        {
            ReiniciarJuego();
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}