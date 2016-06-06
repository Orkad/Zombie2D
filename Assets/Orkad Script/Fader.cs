
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Orkad.UI{

	[RequireComponent(typeof(CanvasGroup),typeof(RectTransform))]
	public class Fader : MonoBehaviour,IShow{
		public RectTransform RectTransform {get { return GetComponent<RectTransform>(); } } 
	    public CanvasGroup CanvasGroup {get { return GetComponent<CanvasGroup>(); } }
	    private bool _show;
		
		public float TransitionDuration = 0.2f;

		private void Update(){
			if(_show)
				CanvasGroup.alpha += Time.deltaTime / TransitionDuration;
			else
				CanvasGroup.alpha -= Time.deltaTime / TransitionDuration;
            CanvasGroup.interactable = CanvasGroup.blocksRaycasts = Shown;
			CanvasGroup.alpha = Mathf.Clamp01(CanvasGroup.alpha);
		}
		
		public void StartHidden(){
			CanvasGroup.alpha = 0f;
			_show = false;
		}
		
		public void StartShown(){
			CanvasGroup.alpha = 1f;
			_show = true;
		}
		
		public void Show(){
			_show = true;
		}
		
		protected virtual void BeforeShow(){}
		
		public void Hide(){
			_show = false;
		}

	    public void InstantShow()
	    {
	        CanvasGroup.alpha = 1f;
	    }

	    public void InstantHide()
	    {
	        CanvasGroup.alpha = 0f;
	    }

	    public bool Shown {get {return CanvasGroup.alpha >= 1f; } } 
        public bool Hidden {get {return CanvasGroup.alpha <= 0f; } } 
	}
}

