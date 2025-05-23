using UnityEngine;

public class estatuasescena3 : MonoBehaviour
{
    public float distancia = 2f; // Distancia máxima a cada lado desde la posición inicial
    public float velocidadMovimiento = 2f; // Velocidad del movimiento lateral
    public float velocidadRotacion = 30f; // Velocidad de rotación

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento lateral en el eje X respecto a la posición inicial
        float desplazamientoX = Mathf.Sin(Time.time * velocidadMovimiento) * distancia;
        transform.position = new Vector3(
            posicionInicial.x + desplazamientoX,
            posicionInicial.y,
            posicionInicial.z
        );

        // Rotación sobre su propio eje Y (opcional)
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.QuitarCorazon();
            // Aquí puedes agregar efectos, sonidos, o empujar al jugador si lo deseas
        }
    }
}



