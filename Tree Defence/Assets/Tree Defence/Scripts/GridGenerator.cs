using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private Cell _prefab;
    [SerializeField] private float _offset;
    [SerializeField] private Transform _parent;

    [ContextMenu("Generate grid")]
    public void GenerateGrid()
    {
        Vector3 cellsize = _prefab.GetComponent<MeshRenderer>().bounds.size;

        Vector3 centerOffset = new Vector3((_gridSize.x - 1) * (cellsize.x + _offset) / 2, 0, (_gridSize.y - 1) * (cellsize.z + _offset) / 2);

        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                Vector3 position = new Vector3(x * (cellsize.x + _offset), 0, y * (cellsize.z + _offset));

                position -= centerOffset;

                Cell cell = Instantiate(_prefab, position, Quaternion.identity, _parent);

                cell.name = $"X: {x} Y: {y}";
            }
        }
    }

    [ContextMenu("Clear grid")]
    public void ClearGrid()
    {
        while (_parent.transform.childCount > 0)
        {
            DestroyImmediate(_parent.transform.GetChild(0).gameObject);
        }
    }

}
