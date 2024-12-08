using System.Collections.Generic;
using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class PatrolBehaviorComponent : BaseEntityComponent
    {
        [SerializeField] private List<Vector3> _points;

        private int _nextPointIndex;

        private void Start()
        {
            if (_nextPointIndex < _points.Count)
            {
                if (TryGetComponent(out MovementComponent movement))
                {
                    movement.SetMoveTarget(_points[_nextPointIndex]);
                }
            }
        }

        private void Update()
        {
            if (_points.Count > 0 &&
                TryGetComponent(out MovementComponent movement) && movement.Moving == false)
            {
                _nextPointIndex++;
                _nextPointIndex %= _points.Count;
                movement.SetMoveTarget(_points[_nextPointIndex]);
            }
        }
    }
}