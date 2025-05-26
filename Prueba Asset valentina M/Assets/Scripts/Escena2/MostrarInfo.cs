using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MostrarInfo : MonoBehaviour
{
    public GameObject panelInfo;
    public TMP_Text tituloTexto;
    public TMP_Text descripcionTexto;
    public Image imagenInfo;

    [Header("Contenido de este objeto")]
    public string titulo;
    public string descripcion;
    public Sprite imagen;

    public void MostrarPanel()
    {
        tituloTexto.text = titulo;
        descripcionTexto.text = descripcion;
        imagenInfo.sprite = imagen;

        panelInfo.SetActive(true);
    }
}
