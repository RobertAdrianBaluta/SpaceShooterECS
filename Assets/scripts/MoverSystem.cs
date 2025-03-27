using Unity.Entities;

public partial struct MoverSystem : ISystem
{
    // Ensures this system will only "update" when there are entities with a SpeedComponent
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SpeedComponent>();
    }

    public void OnUpdate(ref SystemState state)
    {
       float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (translation, speed) in
               SystemAPI.Query<RefRW<Translation>,//RefRW<Translation> = Read/Write access (will modify position)
                              RefRO<SpeedComponent>//RefRO<SpeedComponent> = Read-Only access (just read the speed)
                              >()) 
        {
            // Move the enemy to the right
            translation.ValueRW.Value.x -= speed.ValueRO.speed * deltaTime;
        }
    }
}
