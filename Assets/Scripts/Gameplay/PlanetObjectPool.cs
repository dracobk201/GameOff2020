using UnityEngine;

public class PlanetObjectPool : MonoBehaviour
{
    [SerializeField] private PlanetRuntimeSet planets = null;
    [SerializeField] private IntReference planetPool = null;
    [SerializeField] private GameObject planetPrefab = null;

    private void Awake()
    {
        planets.Items.Clear();
        InstantiatePlanets();
    }

    private void InstantiatePlanets()
    {
        for (int i = 0; i < planetPool.Value; i++)
        {
            GameObject planet = Instantiate(planetPrefab) as GameObject;
            planet.GetComponent<Transform>().SetParent(transform);
            planet.SetActive(false);
            planets.Add(planet);
        }
    }
}
