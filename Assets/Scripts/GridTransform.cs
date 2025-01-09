using UnityEngine;

public class GridTransform : MonoBehaviour
{
    public Vector2 GridPosition = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameHandler.instance.AddGridObject(this);
        transform.position = GameHandler.instance.GetGridZeroPosition() + GridPosition; //we assume grid's size is always 1,1
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
