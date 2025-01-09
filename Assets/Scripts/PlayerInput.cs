using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private GameObject WeaponObject;

    private GridTransform gridTransform;
    private GridMover gridMover;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridTransform = GetComponent<GridTransform>();
        gridMover = GetComponent<GridMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Attack(Vector2.up);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Attack(Vector2.left);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Attack(Vector2.down);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Attack(Vector2.right);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            gridMover.Move(gridTransform.GridPosition + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gridMover.Move(gridTransform.GridPosition + Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            gridMover.Move(gridTransform.GridPosition + Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gridMover.Move(gridTransform.GridPosition + Vector2.right);
        }
    }

    void Attack(Vector2 direction)
    {
        GameObject newWeaponObject = Instantiate(WeaponObject, gridTransform.GridPosition + direction + GameHandler.instance.GetGridZeroPosition(), Quaternion.identity);
        GameObject hitObject = GameHandler.instance.GetGridObjectOnPosition(gridTransform.GridPosition + direction);
        if (hitObject != null)
        {
            Health hitHealth = hitObject.GetComponent<Health>();
            if (hitHealth != null)
            {
                hitHealth.TakeDamage(5f);
            }
        }
        Destroy(newWeaponObject, .2f);
    }
}
