using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class ChaserBehaviorComponent : BaseEntityComponent
    {
        [SerializeField] private float _range;

        private Entity _targetEntity;

        private void Update()
        {
            if (TryGetComponent(out MovementComponent movement) == false ||
                TryGetComponent(out PartyComponent party) == false)
                return;

            if (_targetEntity == null)
            {
                foreach (var (otherParty, otherHealth) in EntityManager.Instance.FilterComponents<PartyComponent, HealthComponent>())
                {
                    if (otherParty.Party != party.Party)
                    {
                        if (Vector3.Distance(otherParty.transform.position, transform.position) < _range)
                        {
                            _targetEntity = otherParty.Entity;
                            break;
                        }
                    }
                }
            }

            if (_targetEntity != null)
            {
                if (Vector3.Distance(_targetEntity.transform.position, transform.position) > _range)
                {
                    _targetEntity = null;
                }
                else
                {
                    movement.SetMoveTarget(_targetEntity.transform.position);
                }
            }
        }
    }
}