using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private GridMover gridMover;
    private GridTransform gridTransform;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridMover = GetComponent<GridMover>();
        gridTransform = GetComponent<GridTransform>();
    }
    
    // push push push pu pu push push do the shit -Laur
    public void Next()
    {
        gridMover.Move(gridTransform.GridPosition + Vector2.right);
    }
}
