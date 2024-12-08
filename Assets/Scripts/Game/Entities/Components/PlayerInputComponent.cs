using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class PlayerInputComponent : BaseEntityComponent
    {
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            var inputDirection = new Vector3(horizontalInput, 0f, verticalInput);
            if (inputDirection.sqrMagnitude > 0.001)
            {
                if (TryGetComponent<MovementComponent>(out var movement))
                {
                    movement.MoveDirection(inputDirection);
                }
            }
        }
    }
}