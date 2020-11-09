using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private BoolReference debugMode = null;
    [SerializeField] private LunarRuntimeSet moons = null;
    [SerializeField] private GameEvent playerShot = null;
    [SerializeField] private Transform bulletInitialPosition = null;

    public void ShootBullet()
    {
        for (int i = 0; i < moons.Items.Count; i++)
        {
            if (!moons.Items[i].activeInHierarchy)
            {
                moons.Items[i].transform.position = bulletInitialPosition.position;
                moons.Items[i].transform.rotation = bulletInitialPosition.rotation;
                moons.Items[i].SetActive(true);
                playerShot.Raise();
                break;
            }
        }
    }
}
