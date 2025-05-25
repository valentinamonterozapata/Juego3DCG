using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Este script controla el movimiento, la rotación y el colisionar con el player de una estatua en la escena 3.
/// </summary>
public class estatuasescena3 : MonoBehaviour

{
    /// <summary>
    /// Distancia máxima que la estatua se moverá a la izquierda y a la derecha.
    /// </summary>
    public float distancia = 2f;

    /// <summary>
    /// Velocidad de movimiento de la estatua.
    /// </summary>
    public float velocidadMovimiento = 2f;

    /// <summary>
    /// Velocidad ne segundos de rotación de la estatua.
    /// </summary>
    public float velocidadRotacion = 30f;

    /// <summary>
    /// Posición inicial de la estatua, utilizada para calcular el movimiento.
    /// </summary>
    private Vector3 posicionInicial;

    /// <summary>
    /// Este método se llama al inicio del juego y guarda la posición inicial de la estatua.
    /// </summary>
    void Start()
    {
        posicionInicial = transform.position;
    }
    /// <summary>
    /// Este método se llama una vez por frame y controla el movimiento y la rotación de la estatua.
    /// </summary>
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
    /// <summary>
    /// Este método se llama cuando otro collider entra en el trigger del objeto al que este script está adjunto.
    /// </summary>
    /// <param name="other">El collider del objeto que entra en contacto.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}




