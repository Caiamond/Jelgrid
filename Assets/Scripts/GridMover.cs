using UnityEngine;

public class GridMover : MonoBehaviour
{
    private GridTransform gridTransform;
    private SpriteRenderer spriteRenderer;

    private bool isMoving = false;
    private float moveDuration = 0.1f;
    private float timeMoved = 0f;
    private Vector2 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridTransform = GetComponent<GridTransform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && timeMoved < moveDuration)
        {
            timeMoved += Time.deltaTime;
            transform.position = Vector2.Lerp(lastPosition, gridTransform.GridPosition, timeMoved/moveDuration) + GameHandler.instance.GetGridZeroPosition();
            if (timeMoved >= moveDuration)
            {
                isMoving = false;
            }
        }
    }

    public void Move(Vector2 newPosition)
    {
        if (newPosition.x > GameHandler.instance.GetGridSize().x-1 || newPosition.y > GameHandler.instance.GetGridSize().y-1
            || newPosition.x < 0 || newPosition.y < 0) { return; }

        if (spriteRenderer)
        {
            if (newPosition.x > gridTransform.GridPosition.x)
            {
                spriteRenderer.flipX = false;
            }
            else if (newPosition.x < gridTransform.GridPosition.x)
            {
                spriteRenderer.flipX = true;
            }
        }

        if (GameHandler.instance.GetGridObjectOnPosition(newPosition) != null) { return; }

        lastPosition = gridTransform.GridPosition;
        gridTransform.GridPosition = newPosition;
        timeMoved = 0f;
        isMoving = true;

        
    }
}
