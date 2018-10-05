using Unity.Entities;
using UnityEngine;

public class InputSystem : ComponentSystem
{

    private struct Data
    {
        public int Length;
        public ComponentArray<InputComponent> InputComponent;
    }

    [Inject] private Data _data;

    protected override void OnUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var jumping = Input.GetKeyDown(KeyCode.Space);

        for(int i=0; i<_data.Length; i++)
        {
            _data.InputComponent[i].Horizontal = horizontal;
            _data.InputComponent[i].Vertical = vertical;
            _data.InputComponent[i].IsJumping = jumping;
        }
    }
}
