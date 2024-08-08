
using UnityEngine;
using Custom.Input;
using static Custom.Input.InputPlayer;
using static Custom.Input.InputUI;


public class InputController : MonoBehaviour
{
    private static InputPlayer _inputPlayer = new InputPlayer();
    private static InputUI _inputUI = new InputUI();
    public static void EnablePlayerInput() => _inputPlayer.Enable();
    public static void DisablePlayerInput() => _inputPlayer.Disable();
    public static void EnableUIInput() => _inputUI.Enable();
    public static void DisableUIInput() => _inputUI.Disable();  
    public static void SubscribeOnPlayerInput(IPlayerActions playerActions)
        {
            _inputPlayer.Player.AddCallbacks(playerActions);
        }
    public static void SubscribeOnUIInput(IUIActions uiActions) 
        {
            _inputUI.UI.AddCallbacks(uiActions);
        }
    public static void UnsubscribeOnPlayerInput(IPlayerActions playerActions)
        {
            _inputPlayer.Player.RemoveCallbacks(playerActions);
        }
    public static void UnsubscribeOnUIInput(IUIActions uIActions)
        {
            _inputUI.UI.RemoveCallbacks(uIActions);
        }
}
