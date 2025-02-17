using UnityEngine;

// This ScriptObject is a real file in unity that can be created by right clicking in a project window and going to
// -> Dialogue/Script Object. Each file is single use and contains a speaker name and their dialogue
namespace UI
{
    [CreateAssetMenu(fileName = "ScriptObject", menuName = "Dialogue/ScriptObject")]
    public class ScriptObject : ScriptableObject
    {
        public string speakerName, speakerText;
    }
}
