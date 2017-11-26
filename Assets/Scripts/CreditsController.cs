using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {

	public void OpenURL(Text txt){
		string url = txt.text.Replace("\n", "").Replace("\r", "");
		Application.OpenURL(url);
	}

}
