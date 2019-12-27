using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public ProjectileType SelectedProjectile = ProjectileType.CANDY_CANE;

    public int CandyCaneCount;
    private int CandyCaneIndex = 0;
    [SerializeField]
    private GameObject CandyCanePrefab;
    [SerializeField]
    private GameObject CandyCaneSpawnPoint;
    private List<GameObject> CandyCanes = new List<GameObject>();

    private bool _fireInput;

    void Start()
    {
        for (int i = 0; i < CandyCaneCount; i++)
        {
            var (position, rotation) = GetSpawnPosition();
            CandyCanes.Add(Instantiate(CandyCanePrefab, position, rotation));
        }

        Debug.Log($"created {CandyCanes.Count} candy canes");
    }

    void Update()
    {
        if (_fireInput && SelectedProjectile == ProjectileType.CANDY_CANE)
        {
            var candyCane = CandyCanes[CandyCaneIndex];
            var (position, rotation) = GetSpawnPosition();

            candyCane.transform.position = position;
            candyCane.transform.rotation = rotation;
            candyCane.SetActive(true);

            if (CandyCaneIndex < CandyCaneCount - 1)
            {
                CandyCaneIndex++;
            }
            else
            {
                CandyCaneIndex = 0;
            }
            _fireInput = false;
        }
    }

    public void Fire(InputAction.CallbackContext context) => _fireInput = context.performed;

    private (Vector3, Quaternion) GetSpawnPosition()
    {
        if (SelectedProjectile == ProjectileType.CANDY_CANE)
        {
            var position = CandyCaneSpawnPoint.transform.position;
            var rotation = CandyCaneSpawnPoint.transform.rotation;
            return (new Vector3(position.x, position.y, position.z), rotation);
        }
        return (new Vector3(), Quaternion.identity);
    }

}
