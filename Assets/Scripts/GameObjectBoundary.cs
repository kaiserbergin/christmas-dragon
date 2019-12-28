using UnityEngine;

public class GameObjectBoundary : MonoBehaviour 
{
    void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}