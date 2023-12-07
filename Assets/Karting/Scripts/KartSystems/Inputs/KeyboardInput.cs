using UnityEngine;
using UnityEngine.InputSystem;

namespace KartGame.KartSystems
{

    public class KeyboardInput : BaseInput
    {
        public bool accelerateState;
        public bool breakState;
        public float turnValue;


        public void AccelerateInput(InputAction.CallbackContext context)
        {
            if (this.isLocalPlayer) 
            {
                accelerateState = context.action.triggered;
            }
        }

        public void BrakeInput(InputAction.CallbackContext context)
        {
            if (this.isLocalPlayer)
            {
                breakState = context.action.triggered;
            }
        }

        public void TurnInput(InputAction.CallbackContext context)
        {
            if (this.isLocalPlayer)
            {
                turnValue = context.action.ReadValue<Vector2>().x;
               // Debug.Log(context.action.ReadValue<Vector2>().x);
            }
        }

        public override InputData GenerateInput()
        {
            return new InputData 
            {
                Accelerate = accelerateState,
                Brake = breakState,
                TurnInput = turnValue
            };
        }
      
    }
}