namespace ReactionGames.TestTask.Game.Entities.Components
{
    public class ShooterBehaviourComponent : BaseEntityComponent
    {
        private void Update()
        {
            if (Entity.TryGetComponent(out PartyComponent party) == false)
                return;

            if (Entity.TryGetComponent(out RangeAttackComponent rangeAttack) == false)
                return;

            foreach (var (otherParty, otherHealth) in EntityManager.Instance.FilterComponents<PartyComponent, HealthComponent>())
            {
                if (otherParty.Party != party.Party)
                {
                    var direction = otherParty.transform.position - transform.position;
                    var distance = direction.magnitude;
                    if (distance < rangeAttack.Range)
                    {
                        var target = otherParty.transform.position + rangeAttack.AttackPositionOffset + direction.normalized * 50f;
                        rangeAttack.Attack(target);
                    }
                }
            }
        }
    }
}