using UnityEngine;

public class GalaxyGenerator : MonoBehaviour
{
    [SerializeField] private LevelRuntimeSet levels = null;
    [SerializeField] private PlanetRuntimeSet planetsPool = null;
    [SerializeField] private LevelData currentLevel = null;
    private int currentLevelIndex = 0;
    private float currentRadius = 80f;

    private void Start()
    {
        PrepareLevel();
    }

    private void PrepareLevel()
    {
        currentLevel = levels.Items[currentLevelIndex];
        PlanetData currentPlanet = null;
        for (int i = 0; i < currentLevel.planetsToPlay.Count; i++)
        {
            currentPlanet = currentLevel.planetsToPlay[i];
            for (int j = 0; j < planetsPool.Items.Count; j++)
            {
                if (!planetsPool.Items[j].activeInHierarchy)
                {
                    planetsPool.Items[j].GetComponent<PlanetBehaviour>().Setup(currentPlanet.size, currentRadius, currentPlanet.velocity);
                    currentRadius *= 1.5f;
                    planetsPool.Items[j].SetActive(true);
                    break;
                }
            }
        }
    }
}
