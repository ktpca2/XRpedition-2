using UnityEngine;

public class WalkieTalkieRespawn : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
       
        transform.position = respawnPoint.transform.position;

    }
}
