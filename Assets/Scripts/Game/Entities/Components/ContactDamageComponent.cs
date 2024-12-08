using ReactionGames.TestTask.Utils;
using UnityEngine;

namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class ContactDamageComponent : BaseEntityComponent
    {
        [SerializeField] private float _damage;

        public float Damage => _damage;

        private void Start()
        {
            var rigidbody = gameObject.GetOrAddComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            rigidbody.isKinematic = false;
            rigidbody.useGravity = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (TryGetComponent(out PartyComponent party) == false)
                return;

            if (collision.gameObject.TryGetComponentInParent(out PartyComponent otherParty) &&
                collision.gameObject.TryGetComponentInParent(out HealthComponent otherHealth) &&
                party.Party != otherParty.Party)
            {
                otherHealth.InflictDamage(_damage);
                EntityManager.Instance.DestroyEntity(Entity);
            }
        }
    }
}