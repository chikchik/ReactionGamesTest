using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class ProjectileComponent : BaseEntityComponent
    {
        [SerializeField] private float _lifeTime;

        private float _spawnTime;

        private void Start()
        {
            _spawnTime = Time.time;
        }

        private void Update()
        {
            if (TryGetComponent(out MovementComponent movement) && movement.Moving == false ||
                Time.time > _spawnTime + _lifeTime)
            {
                EntityManager.Instance.DestroyEntity(Entity);
            }
        }
    }
}