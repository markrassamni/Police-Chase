using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsController : MonoBehaviour {

	[SerializeField] private RectTransform content;
	[SerializeField] private float scrollSpeed;
	private const float scrollDelay = 1f;
	private const float maxScroll = 2610.774f;
	private bool stopScrolling;
	private bool startScrolling;

	IEnumerator Start(){
		// start scrolling after delay
		yield return new WaitForSeconds(scrollDelay);
		startScrolling = true;
	}

	void Update(){
		// scroll until any user input
		if (Input.anyKeyDown || Input.GetAxis("Mouse ScrollWheel") != 0f){
			stopScrolling = true;
		} 
		if(startScrolling && !stopScrolling){
			Scroll();
		}
	}

	private void Scroll(){
		content.anchoredPosition += new Vector2(0f, scrollSpeed);
		if (content.anchoredPosition.y >= maxScroll){
			stopScrolling = true;
			content.anchoredPosition = new Vector2(content.anchoredPosition.x, maxScroll);
		}
	}

	public void OpenURL(Text txt){
		string url = txt.text.Replace("\n", "").Replace("\r", "");
		Application.OpenURL(url);
	}

}
