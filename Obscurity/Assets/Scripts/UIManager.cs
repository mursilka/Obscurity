using UnityEngine;

namespace Obscuity
{
    public class UIManager : MonoBehaviour
    {
        
        [SerializeField] private GameObject _startScreen;
        [SerializeField] private GameObject _gameScreen;
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _fallScreen;
    
        private GameObject _currentScreen;
        private void Awake()
        {
            _startScreen.SetActive(false);
            _gameScreen.SetActive(false);
            _winScreen.SetActive(false);
            _fallScreen.SetActive(false);
            _currentScreen = _startScreen;
            ShowStartScreen();
        }
        
        public void ShowStartScreen()
        {
            _currentScreen.SetActive(false);
            _startScreen.SetActive(true);
            _currentScreen = _startScreen;
    
        }

        public void ShowWinScreen()
        {

            _currentScreen.SetActive(false);
            _winScreen.SetActive(true);
            _currentScreen = _winScreen;
        }

        public void ShowFallScreen()
        {
            _currentScreen.SetActive(false);
            _fallScreen.SetActive(true);
            _currentScreen= _fallScreen;
        }

        public void ShowGameScreen()
        {
            _currentScreen.SetActive(false);
            _gameScreen.SetActive(true);
            _currentScreen = _gameScreen;
        }
    }
}