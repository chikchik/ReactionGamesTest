using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class HealthComponent : BaseEntityComponent
    {
        [SerializeField] private float _health;

        public float Health => _health;
        public float MaxHealth { get; private set; }

        private void Start()
        {
            MaxHealth = _health;
        }

        public void InflictDamage(float damage)
        {
            _health -= damage;

            if (_health < 0f)
                _health = 0f;

            if (_health <= 0f)
            {
                EntityManager.Instance.DestroyEntity(Entity);
            }
        }
    }
}