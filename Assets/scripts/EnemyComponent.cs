using Unity.Entities;
using Unity.Mathematics;

public struct PositionComponent : IComponentData
{
    public float3 position;
}

public struct SpeedComponent : IComponentData
{
    public float speed;
}

public struct Translation : IComponentData
{
    public float3 Value;
}

