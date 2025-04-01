namespace WarsOfShapes
{
    public interface IDamageable
    {
        HealthSystem HealthSystem { get; }
        
        void TakeDamage(int damageAmount) => HealthSystem.TakeDamage(damageAmount);
    }
}
