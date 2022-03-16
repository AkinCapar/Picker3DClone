using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    private Vector3 lastMousePosition;
    private Vector3 difference;
    [SerializeField] float sensivity = 0.25f;
    [SerializeField] float moveSpeed = 1f;
    private float xPos;

    public override void EnterState(PlayerStateManager player)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        MovingForward(player);
        SwerveControl(player);
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }

    private void MovingForward(PlayerStateManager player)
    {
        player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
    }

    private void SwerveControl(PlayerStateManager player)
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            difference = lastMousePosition - Input.mousePosition;
            lastMousePosition = Input.mousePosition;

            xPos = Mathf.Clamp((player.transform.position.x - (difference.x * sensivity)), -4f, 4f);
            player.transform.position = new Vector3(xPos, player.transform.position.y, player.transform.position.z);
        }
    }
}
