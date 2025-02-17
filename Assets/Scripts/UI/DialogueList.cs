using System.Collections.Generic;
using Interactables;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Interactable))]
    public class DialogueList : MonoBehaviour
    {
        public List<ScriptObject> dialogueList;
        public DialogueSystem dialogueSystem;

        public void SendDialogueLists()
        {
            dialogueSystem.PlayLines(dialogueList);
        }
    }
}
