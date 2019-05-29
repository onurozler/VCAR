using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

//Custom 8
public partial class Wit3D : MonoBehaviour {

	public Text myHandleTextBox;
	private bool actionFound = false;


    void Handle (string jsonString) {
		
		if (jsonString != null) {

			RootObject theAction = new RootObject ();
			Newtonsoft.Json.JsonConvert.PopulateObject (jsonString, theAction);

			if (theAction.entities.open != null) {
				foreach (Entity aPart in theAction.entities.open) {
                    if (aPart.value.Contains("drivers door") || aPart.value.Contains("kapı"))
                    {
                        myHandleTextBox.text = "";
                        GetComponent<ARSceneManager>().OpenTheDoor(true);
                        actionFound = true;
                    }
                    else
                        actionFound = false;
                }
			}
			if (theAction.entities.close != null) {
				foreach (Entity aPart in theAction.entities.close) {
                    if (aPart.value.Contains("information") || aPart.value.Contains("özellik"))
                    {
                        myHandleTextBox.text = "";
                        GetComponent<ARSceneManager>().OpenCardInfo(false);
                        actionFound = true;
                    }
                    else if (aPart.value.Contains("drivers door") || aPart.value.Contains("kapı"))
                    {
                        myHandleTextBox.text = "";
                        GetComponent<ARSceneManager>().OpenTheDoor(false);
                        actionFound = true;
                    }
                    else
                        actionFound = false;
                    
				}
			}
            if (theAction.entities.change != null)
            {
                foreach (Entity aPart in theAction.entities.change)
                {
                    if (aPart.value.Contains("color") || aPart.value.Contains("renk"))
                    {
                        myHandleTextBox.text = "";
                        GetComponent<ARSceneManager>().ChangeCarMaterial(false);
                        actionFound = true;
                    }
                    else
                        actionFound = false;

                }
            }
            if (theAction.entities.show != null)
            {
                foreach (Entity aPart in theAction.entities.show)
                {
                    if (aPart.value.Contains("information") || aPart.value.Contains("özellik"))
                    {
                        myHandleTextBox.text = "";
                        GetComponent<ARSceneManager>().OpenCardInfo(true);
                        actionFound = true;
                    }
                    else
                        actionFound = false;
                    
                }
            }


            if (!actionFound) {
				myHandleTextBox.text = _language.CommandManager[4];
            } else {
				actionFound = false;
			}

 		}//END OF IF

 	}//END OF HANDLE VOID

}//END OF CLASS



// Customized by Onur
public class Entity {
	public bool suggested { get; set; }
	public double confidence { get; set; }
	public string value { get; set; }
	public string type { get; set; }
}

public class Entities {
	public List<Entity> open { get; set; }
    public List<Entity> close { get; set; }
    public List<Entity> change { get; set; }
    public List<Entity> show { get; set; }
}

public class RootObject {
	public string _text { get; set; }
	public Entities entities { get; set; }
	public string msg_id { get; set; }
}
