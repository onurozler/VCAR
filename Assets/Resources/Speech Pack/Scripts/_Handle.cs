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
					Debug.Log (aPart.value);
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}
			if (theAction.entities.close != null) {
				foreach (Entity aPart in theAction.entities.close) {
					Debug.Log (aPart.value);
					myHandleTextBox.text = aPart.value;
					actionFound = true;
				}
			}
            if (theAction.entities.change != null)
            {
                foreach (Entity aPart in theAction.entities.change)
                {
                    Debug.Log(aPart.value);
                    myHandleTextBox.text = aPart.value;
                    actionFound = true;
                }
            }


            if (!actionFound) {
				myHandleTextBox.text = "Request unknown, please ask a different way.";
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
}

public class RootObject {
	public string _text { get; set; }
	public Entities entities { get; set; }
	public string msg_id { get; set; }
}
