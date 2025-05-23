using UnityEngine;

public class estatuasescena3 : MonoBehaviour
{
    public float distancia = 2f; // Distancia m�xima a cada lado desde la posici�n inicial
    public float velocidadMovimiento = 2f; // Velocidad del movimiento lateral
    public float velocidadRotacion = 30f; // Velocidad de rotaci�n

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento lateral en el eje X respecto a la posici�n inicial
        float desplazamientoX = Mathf.Sin(Time.time * velocidadMovimiento) * distancia;
        transform.position = new Vector3(
            posicionInicial.x + desplazamientoX,
            posicionInicial.y,
            posicionInicial.z
        );

        // Rotaci�n sobre su propio eje Y (opcional)
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.QuitarCorazon();
            // Aqu� puedes agregar efectos, sonidos, o empujar al jugador si lo deseas
        }
    }
}



