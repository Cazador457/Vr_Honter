using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneChangeManager.Instance.ChangeScene();
            Debug.Log("Se acabo");
        }
    }
}
