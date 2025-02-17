using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace UI
{
	public class DialogueSystem : MonoBehaviour
	{
		// Welcome to the Dialogue System. This is a simple approach to having text appear on the screen
		// based on a rudimentary data type "ScriptObject" fed into a Method in this class

		// These are the references to the dialogue Text Mesh Pro objects
		public TMP_Text nameTMP;
		public TMP_Text textTMP;
		
		// This is a list of the ScriptObjects that we defined above
		private List<ScriptObject> _scriptList;
		
		// This is our fancy animator
		private MMF_Player _mmf;
		
		// This tells other scripts that the dialogue window is active
		public static bool IsActive;
		
		// This controls if the dialogue auto-progresses with a timer
		public bool isTimed;
		private float _timer;
		
		// This reference to the GameObject allows us to turn it off and on when needed
		private GameObject _dialogueObject;

		private void Start()
		{
			// As with many of our scripts, we use Start() to get our important references
			_mmf = GetComponent<MMF_Player>();
			_dialogueObject = transform.GetChild(0).gameObject;
			
			// This sets everything in inactive after the references are set
			_dialogueObject.SetActive(false);
			IsActive = false;
		}

		private void Update()
		{
			// If the dialogue window isn't active, this code doesn't need to run
			if (!IsActive) return;
			
			// If it is active, then pressing E will progress the text
			if (Input.GetKeyDown(KeyCode.E)) NextLine();
			
			// If it's not timed, don't do the below code
			if (!isTimed) return;
			
			// If it is timed, count to 5 and then progress the dialogue
			_timer += Time.deltaTime;
			if (_timer >= 5)
			{
				NextLine();
			}
		}

		// This method sends a full list of ScriptObjects in the parameters
		public void PlayLines(List<ScriptObject> incomingScriptList)
		{
			// Reset the timer if we're using it
			if (isTimed) _timer = 0;
			
			// Set the dialogue window to active and set the boolean to true
			_dialogueObject.SetActive(true);
			IsActive = true;
			
			// The incoming list of ScriptObjects is attached to our list
			_scriptList = incomingScriptList;
			
			// The text is changed to the list member at position 0
			nameTMP.text = _scriptList[0].speakerName;
			textTMP.text = _scriptList[0].speakerText;
			
			// Animate
			_mmf.PlayFeedbacks();
		}

		private void NextLine()
		{
			// Reset the timer if we're using it
			if (isTimed) _timer = 0;
			
			// If the script list only has one member left, it's about it be empty. Close the screen after emptying the list
			if (_scriptList.Count == 0)
			{
				Close();
			}
			// Otherwise, remove the item at position 0 and change the text to match it
			else
			{
				nameTMP.text = _scriptList[0].speakerName;
				textTMP.text = _scriptList[0].speakerText;
				_scriptList.Remove(_scriptList[0]);
				_mmf.PlayFeedbacks();
			}
		}

		private void Close()
		{
			// Reset the text to empty
			nameTMP.text = " ";
			textTMP.text = " ";
			
			// Set the object and boolean to inactive
			IsActive = false;
			_dialogueObject.SetActive(false);
		}
	}
}