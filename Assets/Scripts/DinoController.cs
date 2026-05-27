using UnityEngine;
using UnityEngine.InputSystem;

public class DinoController : MonoBehaviour
{
    private float walk = 5f;
    public InputSystem_Actions dinoActions;
    private Vector2 move;
    private Camera cam;

    void Awake()
    {
        dinoActions = new InputSystem_Actions();
        cam = GetComponent<Camera>();
    }

    void OnEnable()
    {
        dinoActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        temporaryMove();
    }

    void temporaryMove()
    {
        move = dinoActions.Player.Move.ReadValue<Vector2>();
        Vector3 dinoMove = new Vector3(move.x, 0, move.y);

        if (dinoActions.Player.Move.ReadValue<Vector2>().sqrMagnitude > 0.1)
        {
            transform.Translate(dinoMove * walk * Time.deltaTime);
        }
    }
}
