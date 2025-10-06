using UnityEngine;

public class BlockWalls : MonoBehaviour
{
    public GameObject key;
    public GameObject[] wallObs;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == key)
        {
            foreach(GameObject obj in wallObs)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in wallObs)
            {
                if (obj != null)
                    obj.SetActive(true);
            }
        }
    }
}
