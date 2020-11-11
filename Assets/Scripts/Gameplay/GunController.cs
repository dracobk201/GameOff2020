using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private BoolReference debugMode = null;
    [SerializeField] private LunarRuntimeSet moons = null;
    [SerializeField] private FloatReference gunRechargeTime = null;
    [SerializeField] private GameEvent playerShot = null;
    [SerializeField] private Transform bulletInitialPosition = null;
    private bool _recharging;
    private float _actualRechargingTime;

    private void Update()
    {
        if (_recharging)
        {
            _actualRechargingTime -= Time.deltaTime;
            if (_actualRechargingTime <= 0)
                _recharging = false;
        }
    }

    public void ShootAMoon()
    {
        if (_recharging && !debugMode.Value) return;
        for (int i = 0; i < moons.Items.Count; i++)
        {
            if (!moons.Items[i].activeInHierarchy)
            {
                moons.Items[i].transform.position = bulletInitialPosition.position;
                moons.Items[i].transform.rotation = bulletInitialPosition.rotation;
                moons.Items[i].SetActive(true);
                playerShot.Raise();
                _recharging = true;
                _actualRechargingTime = gunRechargeTime.Value;
                break;
            }
        }
    }
}
