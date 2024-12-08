using ReactionGames.TestTask.Utils;
using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class RangeAttackComponent : BaseEntityComponent
    {
        [SerializeField] private float _range;
        [SerializeField] private float _attackInterval;
        [SerializeField] private Entity _projectilePrefab;
        [SerializeField] private Vector3 _attackPositionOffset;

        private float _attackTime;

        public float Range => _range;
        public Vector3 AttackPositionOffset => _attackPositionOffset;

        public void Attack(Vector3 target)
        {
            if (Time.time > _attackTime + _attackInterval)
            {
                SpawnProjectile(target);

                _attackTime = Time.time;
            }
        }

        private void SpawnProjectile(Vector3 target)
        {
            var firePosition = transform.position + AttackPositionOffset;
            var projectileEntity = EntityManager.Instance.CreateEntity(_projectilePrefab);
            projectileEntity.transform.position = firePosition;

            var owner = projectileEntity.GetOrAddComponent<OwnerComponent>();
            owner.Owner = Entity;

            if (Entity.TryGetComponent(out PartyComponent partyComponent))
            {
                var projectileParty = projectileEntity.GetOrAddComponent<PartyComponent>();
                projectileParty.Party = partyComponent.Party;
            }

            var projectileMovement = projectileEntity.GetOrAddComponent<MovementComponent>();
            projectileMovement.SetMoveTarget(target);
        }
    }
}