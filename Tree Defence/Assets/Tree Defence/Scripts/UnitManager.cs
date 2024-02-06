using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    [SerializeField] private Unit _unitPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaceUnit(Cell targetCell)
    {
        if (targetCell.isOccupied)
        {
            Debug.LogError("Cell is already occupied");
            return;
        }

        Vector3 position = targetCell.transform.position;
        float unitHeight = _unitPrefab.GetComponent<MeshRenderer>().bounds.size.y;
        position.y += unitHeight / 2;

        Instantiate(_unitPrefab, position, Quaternion.identity, this.transform);
        targetCell.isOccupied = true;
    }
}
