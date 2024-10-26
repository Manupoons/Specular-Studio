using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementFade : MonoBehaviour
{
    private float fadeOutTimer = 0;
        private float fadeOutDelay = 2;
        public CanvasGroup canvasGroup;
        
        private bool fadeIn;
        private bool fadeOut;
        
        public void FadeAchievement()
        {
            fadeIn = true;
        }
    
    
        private void Start()
        {
            fadeIn = false;
            fadeOut = false;
        }
    
    
    
    
        private void Update()
        {
            if (fadeIn)
            {
                raiseAlpha();
            }
            if (fadeOut)
            {
                decreaseAlpha();
            }
        }
    
    
        private void raiseAlpha()
        {
                
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                    fadeOut = true;
                }
            }
        }
    
        private void decreaseAlpha()
        {
            if (fadeOutTimer<fadeOutDelay)
            {
                fadeOutTimer += Time.deltaTime;
            }
            else
            {
                canvasGroup.alpha -= Time.deltaTime;
                if (canvasGroup.alpha <= 0)
                {
                    fadeOut = false;
                    fadeOutTimer = 0;
                }
            }
            
        }
}
