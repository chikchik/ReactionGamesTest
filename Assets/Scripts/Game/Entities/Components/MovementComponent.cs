using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class MovementComponent : BaseEntityComponent
    {
        [SerializeField] private float _speed;

        private Vector3 _target;
        private bool _moving;

        public bool Moving => _moving;

        private void Update()
        {
            if (_moving)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * _speed);

                if (transform.position == _target)
                {
                    _moving = false;
                }
            }
        }

        public void SetMoveTarget(Vector3 target)
        {
            _target = target;
            _moving = true;
        }

        public void MoveDirection(Vector3 direction)
        {
            var velocity = direction * Time.deltaTime * _speed;
            transform.position += velocity;
        }
    }
}