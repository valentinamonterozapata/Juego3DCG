using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    // Método que recibe el Animation Event llamado "NewEvent"
    public void NewEvent()
    {
        Debug.Log("Evento NewEvent recibido.");
        // Aquí puedes agregar lógica si quieres, o dejarlo vacío
    }
}