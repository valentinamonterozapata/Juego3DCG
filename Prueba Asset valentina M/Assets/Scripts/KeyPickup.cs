//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class KeyPickup : MonoBehaviour
//{
//    public bool hasKey = false;
//    public TextMeshProUGUI keyCounterText; // Asigna el Texto del Canvas
//    public string nextSceneName = "Scene2EC";

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Door") && hasKey) // Si tiene llave y toca la puerta
//        {
//            SceneManager.LoadScene(nextSceneName);
//        }
//    }

//    public void UpdateKeyUI()
//    {
//        keyCounterText.text = "Llave: " + (hasKey ? "1" : "0");
//    }
//}