using UnityEngine;
using UnityEngine.SceneManagement;

public class estatuasescena3 : MonoBehaviour
{
    public float distancia = 2f; // distancia hasta punto inicial
    public float velocidadMovimiento = 2f; // lateral
    public float velocidadRotacion = 30f; //rotación

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        
        float desplazamientoX = Mathf.Sin(Time.time * velocidadMovimiento) * distancia;
        transform.position = new Vector3(
            posicionInicial.x + desplazamientoX,
            posicionInicial.y,
            posicionInicial.z
        );

        
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}




