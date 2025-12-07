using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    float speed = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
}
