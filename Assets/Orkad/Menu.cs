using UnityEngine;
using UnityEngine.UI;

namespace Orkad.UI
{
    [RequireComponent(typeof(IShow))]
    public class Menu : MonoBehaviour
    {
        public IShow Shower { get { return GetComponent<IShow>(); } }
        private Menu _previousMenu;
        public Button BackButton;
        public bool StartActive = false;
		public bool center = true;

        public virtual void Start()
        {
            if (StartActive)
                Shower.Show();
            else
                Shower.InstantHide();
			if(center)
				GetComponentInChildren<RectTransform>().position = new Vector2(Screen.width / 2,Screen.height /2);
            if (BackButton != null)
                BackButton.onClick.AddListener(Back);
        }

        public void Stack(Menu nextMenu)
        {
            if (nextMenu == null)
                return;
            nextMenu._previousMenu = this;
            nextMenu.OnStack();
            nextMenu.Shower.Show();
            Shower.Hide();
        }

        public void Back()
        {
            if (_previousMenu == null)
            {
                Application.Quit();
                return;
            }
            OnBack();
            Shower.Hide();
            _previousMenu.Shower.Show();

        }

        protected virtual void OnBack() { }
        protected virtual void OnStack() { }
    }

}
