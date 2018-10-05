//using Unity.Collections;
//using Unity.Entities;
//using Unity.Jobs;
//using UnityEngine;

//public class PlayerShootingSystem : JobComponentSystem {

//    private struct PlayerShootingJob : IJobParallelFor
//    {
//        [ReadOnly] public EntityArray EntityArray;
//        public EntityCommandBuffer/*.Concurrent*/ EntityCommandBuffer;
//        public bool isFiring;

//        public void Execute(int index)
//        {
//            if (!isFiring) return;
//            EntityCommandBuffer.AddComponent(EntityArray[index], new Firing());
//        }
//    }

//    private struct Data
//    {
//        public readonly int Length;
//        public EntityArray Entities;
//        public ComponentDataArray<Weapon> Weapons;
//        //To make sur we don't add an entity with already Firing
//        public SubtractiveComponent<Firing> Firings;
//    }

//    [Inject] private Data _data;
//    [Inject] private PlayerShootingBarrier _barrier;

//    protected override JobHandle OnUpdate(JobHandle inputDeps)
//    {
//        return new PlayerShootingJob
//        {
//            EntityArray = _data.Entities,
//            EntityCommandBuffer = _barrier.CreateCommandBuffer(),
//            isFiring = Input.GetButton("Fire1")
//        }.Schedule(_data.Length, 64, inputDeps);
//    }
//}

//public class PlayerShootingBarrier : BarrierSystem
//{

//}
