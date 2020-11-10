using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    [SerializeField] private Transform planetTransform = null;
    private float _radius = 50f;
    private float _velocity;
    private float _angle;

    private void Update()
    {
        _angle += Time.deltaTime * _velocity;
        transform.position = new Vector3(Mathf.Cos(_angle) * _radius, 0,  Mathf.Sin(_angle) * _radius);
    }

    public void Setup(Vector3 scale, float radius, float velocity)
    {
        planetTransform.localScale = scale;
        _radius = radius;
        _velocity = velocity;
    }
}
