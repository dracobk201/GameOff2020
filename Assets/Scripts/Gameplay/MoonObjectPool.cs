using UnityEngine;

public class MoonObjectPool : MonoBehaviour
{
    [SerializeField] private LunarRuntimeSet moons = null;
    [SerializeField] private IntReference moonPool = null;
    [SerializeField] private GameObject moonPrefab = null;

    private void Awake()
    {
        moons.Items.Clear();
        InstantiateMoons();
    }

    private void InstantiateMoons()
    {
        for (int i = 0; i < moonPool.Value; i++)
        {
            GameObject planet = Instantiate(moonPrefab) as GameObject;
            planet.GetComponent<Transform>().SetParent(transform);
            planet.SetActive(false);
            moons.Add(planet);
        }
    }
}
