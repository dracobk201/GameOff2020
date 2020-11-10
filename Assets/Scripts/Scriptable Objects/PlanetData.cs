using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Planet")]
public class PlanetData : ScriptableObject
{
    public Vector3 size;
    public int moonOrbits;
    public float velocity;
}
