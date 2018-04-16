using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Color buttonidle = new Color32(0xFF, 0xFF, 0xFF, 0xFF); 
    Color buttonhovered = new Color32(0x71, 0x71, 0xB2, 0xFF);
    Color exitbuttonidle = new Color32(0xB2, 0x71, 0x71, 0xFF);
    //Speichert die Farben der Buttons in Color Variablen
    private void Start()
    {
        GetComponent<Image>().color = buttonidle; //Setzt das Quadrat auf die Idle Farbe
    }
    public void HoverColour()
    {
        GetComponent<Image>().color = buttonhovered; //Setzt das Quadrat auf die angedachte Farbe beim Hovern
    }
    public void ExitColour ()
    {
        GetComponent<Image>().color = buttonidle; //Setzt beim Verlassen auf die Idle Farbe zurück
    }
    public void HoverColourExitButton ()
    {
        GetComponent<Image>().color = exitbuttonidle; //Setzt das Quadrat auf die angedachte Farbe beim Hovern welche beim Exit Button anders ist im Vergleich zu anderen Buttons
    }
}
