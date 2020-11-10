using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Level")]
public class LevelData : ScriptableObject
{
    public float timeToBeat;
    public List<PlanetData> planetsToPlay;
}
