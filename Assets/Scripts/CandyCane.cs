using UnityEngine;

public class CandyCane : Projectile
{
    public float fowardSpeed = 1.0f;
    public float rotationSpeed = 1.0f;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
        _rigidbody.velocity = _rigidbody.transform.up * fowardSpeed;
        _rigidbody.angularVelocity = _rigidbody.transform.up * rotationSpeed;
    }
}
