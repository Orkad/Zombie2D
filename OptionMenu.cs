using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour {
	public InputField InputFieldPlayerName;
	public InputField InputFieldGroupName;
	public Dropdown DropdownGroupMaxPlayer;
	public Button ButtonApply;

	void Start(){
		InputFieldPlayerName.onValueChanged.AddListener ((s) => ButtonApply.interactable = true);
		InputFieldGroupName.onValueChanged.AddListener((s) => ButtonApply.interactable = true);
		DropdownGroupMaxPlayer.onValueChanged.AddListener((i) => ButtonApply.interactable = true);
		if(ButtonApply)ButtonApply.onClick.AddListener (Save);
		Load ();
	}

	void Load(){
		InputFieldPlayerName.text = Data.PlayerName;
		InputFieldGroupName.text = Data.GroupName;
		DropdownGroupMaxPlayer.value = DropDownSearch (DropdownGroupMaxPlayer, Data.GroupMaxPlayer.ToString ());
		ButtonApply.interactable = false;
	}

	void Save(){
		Data.PlayerName.Set(InputFieldPlayerName.text);
		Data.GroupName.Set(InputFieldGroupName.text);
		Data.GroupMaxPlayer.Set(int.Parse (DropdownGroupMaxPlayer.options[DropdownGroupMaxPlayer.value].text));
		ButtonApply.interactable = false;
	}

	/// <summary>
	/// Recherche dans un dropdown la valeur str passée en paramètre
	/// </summary>
	/// <returns>L'index correspondant dans la liste "options"</returns>
	/// <param name="dropDown">DropDown concerné</param>
	/// <param name="str">chaine recherchée</param>
	static int DropDownSearch(Dropdown dropDown, string str){
		for(int i = 0; i < dropDown.options.Count ; i++)
			if (str == dropDown.options [i].text)
				return i;
		return 0;
	}
}
