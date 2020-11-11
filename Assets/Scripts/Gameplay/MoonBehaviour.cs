using UnityEngine;

public class MoonBehaviour : MonoBehaviour
{
    [SerializeField] private FloatReference moonVelocity = null;
    [SerializeField] private FloatReference moonTimeOfLife = null;
    [SerializeField] private GameEvent planetImpacted = null;
    private float _actualTimeProgress;
    private Rigidbody moonRigidbody;

    private void OnEnable()
    {
        if (TryGetComponent(out Rigidbody rigidbodyResult))
            moonRigidbody = rigidbodyResult;
        else
            Debug.LogError("No Rigidbody found");
        Vector3 aux = transform.forward * moonVelocity.Value;
        moonRigidbody.useGravity = false;
        moonRigidbody.velocity = aux;
        _actualTimeProgress = moonTimeOfLife.Value;
    }

    private void Update()
    {
        _actualTimeProgress -= Time.deltaTime;
        if (_actualTimeProgress <= 0)
            DestroyMoon();
    }

    public void DestroyMoon()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.PlanetTag))
            planetImpacted.Raise();
    }
}
