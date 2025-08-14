using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UIElements;

public enum Direction { Forward, Down, Left, Right, None }
public class Player : MonoBehaviour
{
    public LayerMask layerBrick;
    public float speed;
    public Transform playerBrickPrefab;
    public Transform playerSkin;
    public Transform brickHolder;
    private Vector3 mouseDown, mouseUp;
    public Vector3 movePoint;
    private bool isMoving = false;
    private bool isControl;
    private bool isDead = false;
    List<Transform> playerBricks = new List<Transform>();


    void Update()
    {
        if (isDead)
        {
            UIManager.Instance.OpenDeadUI();
            GameManager.Instance.ChangeState(GameState.MainMenu);
            return;
        }
        if (GameManager.Instance.IsState(GameState.Playing) && !isMoving)
        {

            if (Input.GetMouseButtonDown(0) && !isControl)
            {
                isControl = true;
                mouseDown = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0) && isControl)
            {
                isControl = false;
                mouseUp = Input.mousePosition;
                Direction direction = GetDirection(mouseDown, mouseUp);
                if (direction != Direction.None)
                {
                    isMoving = true;
                    movePoint = GetNextBrick(direction);
                }

            }
        }
        else if (isMoving)
        {
            if (Vector3.Distance(transform.position, movePoint) < 0.1f)
            {
                isMoving = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);

        }
    }
    public void OnInit()
    {
        isMoving = false;
        isControl = false;
        isDead = false;
        ClearBricks();
        playerSkin.localPosition = Vector3.zero;
    }
    public void AddBrick()
    {
        int index = playerBricks.Count;
        Transform playerBrick = Instantiate(playerBrickPrefab, brickHolder);
        playerBrick.localPosition = Vector3.down + index * 0.25f * Vector3.up;
        playerBricks.Add(playerBrick);
        playerSkin.localPosition = playerSkin.localPosition + Vector3.up * 0.25f;
    }
    public void RemoveBrick()
    {
        int index = playerBricks.Count - 1;

        if (index >= 0)
        {
            Transform playerBrick = playerBricks[index];
            playerBricks.Remove(playerBrick);
            Destroy(playerBrick.gameObject);
            playerSkin.localPosition = playerSkin.localPosition - Vector3.up * 0.25f;
        }
        else
        {
            isDead = true;
        }
    }
    public void ClearBricks()
    {
        for (int i = 0; i < playerBricks.Count; i++)
        {
            Destroy(playerBricks[i].gameObject);
        }
        playerBricks.Clear();
        playerSkin.localPosition = Vector3.zero;

    }
    private Vector3 GetNextBrick(Direction direction)
    {
        RaycastHit hit;
        Vector3 nextBrick = transform.position;
        Vector3 dir = Vector3.zero;
        switch (direction)
        {
            case Direction.Forward:
                dir = Vector3.forward;
                break;
            case Direction.Down:
                dir = Vector3.back;
                break;
            case Direction.Left:
                dir = Vector3.left;
                break;
            case Direction.Right:
                dir = Vector3.right;
                break;
            default:
                break;
        }

        for (int i = 1; i < 100; i++)
        {
            if (Physics.Raycast(transform.position + dir * i + Vector3.up * 2, Vector3.down, out hit, 10f, layerBrick))
            {
                nextBrick = hit.collider.transform.position;
            }
            else
            {
                break;
            }
        }
        return nextBrick;

    }
    private Direction GetDirection(Vector3 mouseDown, Vector3 mouseUp)
    {
        Direction direction = Direction.None;
        float deltaX = mouseUp.x - mouseDown.x;
        float deltaY = mouseUp.y - mouseDown.y;

        if (Vector3.Distance(mouseDown, mouseUp) < 100)
        {
            direction = Direction.None;
        }
        else
        {
            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                if (deltaX > 0)
                {
                    direction = Direction.Right;
                }
                else
                {
                    direction = Direction.Left;
                }
            }
            else
            {
                if (deltaY > 0)
                {
                    direction = Direction.Forward;
                }
                else
                {
                    direction = Direction.Down;
                }
            }
        }
        return direction;
    }
}
