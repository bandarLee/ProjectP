using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float speed = 1.5f;
    public Transform initialPosition;
    public Transform arrivePosition;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,arrivePosition.position, speed * Time.deltaTime);
    }
}
