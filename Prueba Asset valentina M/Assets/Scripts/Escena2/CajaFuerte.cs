using UnityEngine;
using TMPro;

/// <summary>
/// Controla la lógica de una caja fuerte interactiva con código numérico.
/// Permite ingresar, borrar, verificar un código y activar elementos visuales y sonoros en función del resultado.
/// </summary>
public class CajaFuerte : MonoBehaviour
{
    /// <summary>
    /// Código correcto que debe ingresar el jugador para abrir la caja fuerte.
    /// </summary>
    public string codigoCorrecto = "2864";

    /// <summary>
    /// Código actual ingresado por el jugador.
    /// </summary>
    private string codigoIngresado = "";

    /// <summary>
    /// Texto de la interfaz donde se muestra el código ingresado.
    /// </summary>
    public TMP_Text displayCodigo;

    /// <summary>
    /// Panel de la interfaz que permite ingresar el código.
    /// </summary>
    public GameObject panelCodigoUI;

    /// <summary>
    /// Objeto que representa la maleta abierta que se activa al ingresar el código correcto.
    /// </summary>
    public GameObject objetoMaletaAbierta;

    /// <summary>
    /// Sonido que se reproduce al ingresar el código correcto.
    /// </summary>
    public AudioSource sonidoCorrecto;

    /// <summary>
    /// Sonido que se reproduce al ingresar un código incorrecto.
    /// </summary>
    public AudioSource sonidoIncorrecto;

    /// <summary>
    /// Agrega un número al código ingresado, si no se ha alcanzado la longitud del código correcto.
    /// </summary>
    /// <param name="numero">Número en forma de string que será añadido al código ingresado.</param>
    public void IngresarNumero(string numero)
    {
        if (codigoIngresado.Length < codigoCorrecto.Length)
        {
            codigoIngresado += numero;
            displayCodigo.text = codigoIngresado;
        }
    }

    /// <summary>
    /// Borra el código ingresado y limpia el display.
    /// </summary>
    public void Borrar()
    {
        codigoIngresado = "";
        displayCodigo.text = "";
    }

    /// <summary>
    /// Verifica si el código ingresado coincide con el correcto.
    /// Si es correcto, reproduce sonido, oculta el panel y muestra la maleta abierta.
    /// Si es incorrecto, reproduce un sonido de error y reinicia el ingreso.
    /// </summary>
    public void VerificarCodigo()
    {
        if (codigoIngresado == codigoCorrecto)
        {
            Debug.Log("Código correcto");
            if (sonidoCorrecto) sonidoCorrecto.Play();

            panelCodigoUI.SetActive(false);
            if (objetoMaletaAbierta != null)
                objetoMaletaAbierta.SetActive(true);

            codigoIngresado = "";
            displayCodigo.text = "";
        }
        else
        {
            Debug.Log("Código incorrecto");
            if (sonidoIncorrecto) sonidoIncorrecto.Play();

            codigoIngresado = "";
            displayCodigo.text = "";
        }
    }

    /// <summary>
    /// Cierra el panel de código manualmente y limpia la entrada.
    /// </summary>
    public void CerrarPanel()
    {
        Debug.Log("Cerrar panel de código");
        panelCodigoUI.SetActive(false);

        codigoIngresado = "";
        displayCodigo.text = "";
    }
}
