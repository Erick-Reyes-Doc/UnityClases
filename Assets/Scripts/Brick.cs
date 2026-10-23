
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Contar todos los bloques con el Tag Brick
            int bloques = GameObject.FindGameObjectsWithTag("Block").Length;

            // Destruir el bloque golpeado
            Destroy(gameObject);

            // Comprobar si era el ultimo bloque
            if (bloques == 1)
            {
                Debug.Log("¡Ganaste!");

                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex
                );
            }
        }
    }
}
