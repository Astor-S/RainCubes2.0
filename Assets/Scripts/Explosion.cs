using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _power;

    public void Explode()
    {
        Collider[] affectedColliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in affectedColliders)
        {
            Rigidbody rigidbody = collider.attachedRigidbody;

            if (rigidbody != null)
                rigidbody.AddExplosionForce(_power, transform.position, _radius);
        }
    }
}