using UnityEngine;
using Random = UnityEngine.Random;

public class Coins : MonoBehaviour, IFly, IRotation
{
    private Transform _transform;
    private Collider _collider;
    private Renderer _renderer;

    public Renderer Renderer { get => _renderer; set => _renderer = value; }

    private bool _isInteractable;
    private float heightFly;
    private float speedRotation;

    public bool IsInteractable
    {
        get => _isInteractable;
        set
        {
            _isInteractable = value;
            _renderer.enabled = value;
            _collider.enabled = value;
        }
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();

        heightFly = Random.Range(1f, 5f);
        speedRotation = Random.Range(10f, 50f);
    }

    private void Update()
    {
        Fly();
        Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsInteractable = false;
        }
    }

    public void Fly()
    {
        _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, heightFly), _transform.position.z);
    }

    public void Rotate()
    {
        _transform.Rotate(Vector3.up * (Time.deltaTime * speedRotation), Space.World);
    }
}
