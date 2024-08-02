using StarterAssets;
using UnityEngine;

public class JoystickController : MonoBehaviour {

    public VariableJoystick variableJoystick;    
    //public DynamicJoystick LookJoystick;
    public StarterAssetsInputs starterAssetsInputs;

    void Update() {
        starterAssetsInputs.MoveInput(new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical));
        //starterAssetsInputs.LookInput(new Vector2(LookJoystick.Horizontal, LookJoystick.Vertical));
    }
}
