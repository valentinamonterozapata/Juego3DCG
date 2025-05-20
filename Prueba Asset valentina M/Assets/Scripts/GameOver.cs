using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
