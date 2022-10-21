using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rb;

    private void Awake()
    {
        Time.timeScale = 1f;

        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }
}
