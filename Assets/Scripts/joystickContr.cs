using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class joystickContr : MonoBehaviour, IPointerUpHandler
{
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private PlayerController playerController;

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
