using System.Collections;
using System.Collections.Generic;
using CodeMVC.UserInput;
using UnityEngine;
using UnityEngine.EventSystems;
public class joystickContr : MonoBehaviour, IPointerUpHandler
{
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private PlayerControllerMB playerController;

    public void OnPointerUp(PointerEventData eventData)
    {
        ((IPointerUpHandler)joystick).OnPointerUp(eventData);

        playerController.ChangeState();
        
    }
    /*
public void OnPointerUp(PointerEventData eventData)
{
   ((IPointerUpHandler)joystick).OnPointerUp(eventData);
   print("q");
}
*/


}
