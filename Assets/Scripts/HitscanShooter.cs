using UnityEngine;
using UnityEngine.InputSystem;

public class HitscanShooter : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private AimRayProvider aim;
    [Header("Settings")]
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private LayerMask hitMask = ~0;
    [SerializeField] private int damage = 10;

    private PlayerControls controls;

    void Reset()
    {
        aim = FindFirstObjectByType<AimRayProvider>();
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Fire.performed += OnFire;
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    public void OnFire(InputAction.CallbackContext _)
    {
        Ray ray = aim.GetRayFromCursor();
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, hitMask))
        {
            var hp = hit.collider.GetComponent<Health>();
            if (hp != null) hp.TakeDamage(damage);
        }
    }
}