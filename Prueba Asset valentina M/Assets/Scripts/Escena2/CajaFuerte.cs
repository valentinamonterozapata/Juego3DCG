using UnityEngine;
using TMPro;

public class CajaFuerte : MonoBehaviour
{
    public string codigoCorrecto = "1234";
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
            if (sonidoCorrecto && !sonidoCorrecto.isPlaying) sonidoCorrecto.Play();

            if (panelCodigoUI != null)
                panelCodigoUI.SetActive(false);

            if (objetoMaletaAbierta != null)
                objetoMaletaAbierta.SetActive(true);

            // Evita que se vuelva a abrir
            Maleta maleta = FindObjectOfType<Maleta>();
            if (maleta != null)
            {
                maleta.BloquearMaleta();
            }
        }
        else
        {
            Debug.Log("Código incorrecto");
            if (sonidoIncorrecto) sonidoIncorrecto.Play();
            Borrar();
        }
    }

    public void CerrarPanel()
    {
        panelCodigoUI.SetActive(false);  // Oculta el panel
        Borrar();                         // Limpia el código ingresado y el display
    }
}
