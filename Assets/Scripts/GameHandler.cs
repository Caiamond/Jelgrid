using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    private List<GridTransform> GridObjects = new();

    [SerializeField]
    private GameObject GridObject;
    [SerializeField]
    private Vector2 GridSize = Vector2.zero;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewGrid()
    {
        Vector2 zeroPosition = GetGridZeroPosition();

        for (int i = 0; i < GridSize.x; i++)
        {
            for (int j = 0; j < GridSize.y; j++)
            {
                Instantiate(GridObject, new Vector2(i, j) + zeroPosition, Quaternion.identity);
            }
        }
    }

    public Vector2 GetGridSize()
    {
        return GridSize;
    }

    public Vector2 GetGridZeroPosition()
    {
        return -(GridSize - Vector2.one) / 2f;
    }

#nullable enable
    public GameObject? GetGridObjectOnPosition(Vector2 position)
    {
        foreach (GridTransform gridTransform in GridObjects)
        {
            if (gridTransform.GridPosition == position)
            {
                return gridTransform.gameObject;
            }
        }

        return null;
    }

    public void AddGridObject(GridTransform gridTransform)
    {
        GridObjects.Add(gridTransform);
    }
#nullable enable
}
