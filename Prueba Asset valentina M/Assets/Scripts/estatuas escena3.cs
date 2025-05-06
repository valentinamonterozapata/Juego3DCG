using UnityEngine;

public class estatuasescena3 : MonoBehaviour
{
    
    public float altura = 2f;
    public float velocidadMovimiento = 2f; 

    
    public float velocidadRotacion = 30f; 

    private Vector3 posicionInicial;

    
    void Start()
    {
        
        posicionInicial = transform.position;
    }

    
    void Update()
    {
        
        float desplazamientoY = Mathf.Sin(Time.time * velocidadMovimiento) * altura;
        transform.position = new Vector3(posicionInicial.x, posicionInicial.y + desplazamientoY, posicionInicial.z);

        
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}


