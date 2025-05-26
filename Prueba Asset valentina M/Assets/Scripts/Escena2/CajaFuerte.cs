using UnityEngine;
using TMPro;

public class CajaFuerte : MonoBehaviour
{
    public string codigoCorrecto = "2864";
    private string codigoIngresado = "";

    public TMP_Text displayCodigo;
    public GameObject panelCodigoUI;
    public GameObject objetoMaletaAbierta;
    public AudioSource sonidoCorrecto;
    public AudioSource sonidoIncorrecto;

    public void IngresarNumero(string numero)
    {
        if (codigoIngresado.Length < codigoCorrecto.Length)
        {
            codigoIngresado += numero;
            displayCodigo.text = codigoIngresado;
        }
    }

    public void Borrar()
    {
        codigoIngresado = "";
        displayCodigo.text = "";
    }

    public void VerificarCodigo()
    {
        if (codigoIngresado == codigoCorrecto)
        {
            Debug.Log("Código correcto");
            if (sonidoCorrecto) sonidoCorrecto.Play();

            panelCodigoUI.SetActive(false);
            if (objetoMaletaAbierta != null)
                objetoMaletaAbierta.SetActive(true);

            // Limpieza
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

    public void CerrarPanel()
    {
        Debug.Log("Cerrar panel de código");
        panelCodigoUI.SetActive(false);

        // Limpieza del código y display
        codigoIngresado = "";
        displayCodigo.text = "";
    }
}