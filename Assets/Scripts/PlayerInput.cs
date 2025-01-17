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
            Move(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2.right);
        }
    }

    void Move(Vector2 direction)
    {
        gridMover.Move(gridTransform.GridPosition + direction);
        GameHandler.instance.Next.Invoke();
    }

    void Attack(Vector2 direction)
    {
        GameObject newWeaponObject = Instantiate(WeaponObject, gridTransform.GridPosition + direction + GameHandler.instance.GetGridZeroPosition(), Quaternion.Euler(0, 0, GetRotationDegreeForDirection(direction)));
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

        GameHandler.instance.Next.Invoke();
    }

    float GetRotationDegreeForDirection(Vector2 direction)
    {
        if (direction == Vector2.up)
        {
            return 90;
        }
        else if (direction == Vector2.left)
        {
            return 180;
        }
        else if (direction == Vector2.down)
        {
            return 270;
        }
        return 0;
    }
}
