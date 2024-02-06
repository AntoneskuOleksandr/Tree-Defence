using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Color _standartColor;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _occupiedColor;

    [SerializeField] private MeshRenderer _meshRenderer;

    public Vector2Int gridPosition;
    private bool _occupied;
    private UnitManager unitManager;

    public bool isOccupied
    {
        get
        {
            return _occupied;
        }
        set
        {
            _occupied = value;
            ChangeColor(_occupied ? _occupiedColor : _standartColor);
        }
    }

    private void Awake()
    {
        ChangeColor(_standartColor);
    }

    private void Start()
    {
        unitManager = UnitManager.Instance;
    }

    private void OnMouseEnter()
    {
        if (!_occupied)
        {
            ChangeColor(_hoverColor);
        }
    }

    private void OnMouseExit()
    {
        if (!_occupied)
        {
            ChangeColor(_standartColor);
        }
    }
    private void OnMouseDown()
    {
        if (!isOccupied)
        {
            if (unitManager != null)
            {
                unitManager.PlaceUnit(this);
            }
        }
    }

    private void ChangeColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}
