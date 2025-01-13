using System;
using Controllers;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIInitialSequence : MonoBehaviour
    {
        // Reference
        public LevelInformation levelInformation;
        
        // Text
        public TMP_Text levelInfoTMP;
        public TMP_Text controlInfoTMP;
        
        //MMFs
        public MMF_Player levelInfo;
        public MMF_Player controlInfo;

        // Timer Info
        private bool _infoTriggered;
        private float _timer;

        public float timeLimit;

        private void Start()
        {
            ReplaceLevelInfo();
            levelInfo.PlayFeedbacks();
            _infoTriggered = true;
            _timer = 0;
        }

        public void ReplaceLevelInfo()
        {
            levelInfoTMP.text = levelInformation.levelName;
            controlInfoTMP.text = levelInformation.yourName;
        }

        private void Update()
        {
            if (!_infoTriggered) return;
            
            _timer += Time.deltaTime;
            if (_timer >= timeLimit)
            {
                controlInfo.PlayFeedbacks();
                _infoTriggered = false;
            }
        }
    }
}
