using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class MovingSystemBase : SystemBase
{
	protected override void OnUpdate ()
	{
		Entities.ForEach((ref LocalTransform transform, ref TargetPosition targetPosition, in Speed speed) =>
				 {
					 float3 direction = math.normalize(targetPosition.value - transform.Position);
					 transform.Position += direction * SystemAPI.Time.DeltaTime * speed.value;
				 })
				.Schedule();
	}
}
