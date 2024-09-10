using UnityEngine;

public class PermBuffManager : MonoBehaviour
{

    public CurrencyManager currencyManager;
    public HealthBuffManager healthBuffManager;
    public AttackSpeedBuffManager attackSpeedBuffManager;
    public AttackDamageBuffManager attackDamageManager;
    public MoveSpeedBuffManager moveSpeedBuffManager;

    void Start() {
        healthBuffManager = new HealthBuffManager(currencyManager);
        attackSpeedBuffManager = new AttackSpeedBuffManager(currencyManager);
        attackDamageManager = new AttackDamageBuffManager(currencyManager);
        moveSpeedBuffManager = new MoveSpeedBuffManager(currencyManager);
    }

    public class HealthBuffManager {
        private CurrencyManager currencyManager;
        private int currentLevel = 0;
        private int maxLevel = 4;
        private float value = 0.0f;

        private float[] costLevels = new float[] { 50.0f, 100.0f, 200.0f, 300.0f};
        private float[] valueLevels = new float[] { 10.0f, 50.0f, 100.0f, 200.0f};

        public HealthBuffManager(CurrencyManager _currencyManager) {
            currencyManager = _currencyManager;
            value = PlayerPrefs.GetFloat("playerHealthBuff");
            if (value != null && value > 0) {
                currentLevel = determineLevelFromValue();
            }
        }

        private int determineLevelFromValue() {
            for (int i = 0; i < valueLevels.Length; i++) {
                if (i == valueLevels.Length-1) return i+1;
                if (value >= valueLevels[i]) {
                    if (value < valueLevels[i+1]) {
                        return i+1;
                    }
                }
            }
            return 0;
        }

        private void updateValueStore() {
            PlayerPrefs.SetFloat("playerHealthBuff", value);
        }

        public void LevelUp() {
            if (currencyManager != null) {
                Debug.LogError("currencyManager not found!");
                return;
            }
            if (currentLevel < maxLevel) {
                int tmpNewLevel = currentLevel + 1;
                if (currencyManager.GetBalance() >= costLevels[tmpNewLevel]) {
                    currencyManager.DecreaseBalance(costLevels[tmpNewLevel]);
                    value = valueLevels[tmpNewLevel];
                    updateValueStore();
                    currentLevel = tmpNewLevel;
                } else {
                    Debug.LogError("Cannot afford buff!");
                    return;
                }
            } else {
                Debug.Log("Already max level!");
                return;
            }
        }

        public int GetCurrentLevel() { return currentLevel;}
        public bool CanAffordUpgrade() {
            return currencyManager != null && currencyManager.GetBalance() >= costLevels[currentLevel + 1];
        }
    }

    public class AttackSpeedBuffManager {
        private CurrencyManager currencyManager;
        private int currentLevel = 0;
        private int maxLevel = 4;
        private float value = 0.0f;

        private float[] costLevels = new float[] { 50.0f, 100.0f, 200.0f, 300.0f};
        private float[] valueLevels = new float[] { 0.05f, 0.1f, 0.15f, 0.2f};

        public AttackSpeedBuffManager(CurrencyManager _currencyManager) {
            currencyManager = _currencyManager;
            value = PlayerPrefs.GetFloat("attackSpeedBuff");
            if (value != null && value > 0) {
                currentLevel = determineLevelFromValue();
            }
        }

        private int determineLevelFromValue() {
            for (int i = 0; i < valueLevels.Length; i++) {
                if (i == valueLevels.Length-1) return i+1;
                if (value >= valueLevels[i]) {
                    if (value < valueLevels[i+1]) {
                        return i+1;
                    }
                }
            }
            return 0;
        }

        private void updateValueStore() {
            PlayerPrefs.SetFloat("attackSpeedBuff", value);
        }

        public void LevelUp() {
            if (currencyManager != null) {
                Debug.LogError("currencyManager not found!");
                return;
            }
            if (currentLevel < maxLevel) {
                int tmpNewLevel = currentLevel + 1;
                if (currencyManager.GetBalance() >= costLevels[tmpNewLevel]) {
                    currencyManager.DecreaseBalance(costLevels[tmpNewLevel]);
                    value = valueLevels[tmpNewLevel];
                    updateValueStore();
                    currentLevel = tmpNewLevel;
                } else {
                    Debug.LogError("Cannot afford buff!");
                    return;
                }
            } else {
                Debug.Log("Already max level!");
                return;
            }
        }

        public int GetCurrentLevel() { return currentLevel;}
        public bool CanAffordUpgrade() {
            return currencyManager != null && currencyManager.GetBalance() >= costLevels[currentLevel + 1];
        }
    }

    public class AttackDamageBuffManager {
        private CurrencyManager currencyManager;
        private int currentLevel = 0;
        private int maxLevel = 4;
        private float value = 0.0f;

        private float[] costLevels = new float[] { 50.0f, 100.0f, 200.0f, 300.0f};
        private float[] valueLevels = new float[] { 10.0f, 50.0f, 100.0f, 200.0f};

        public AttackDamageBuffManager(CurrencyManager _currencyManager) {
            currencyManager = _currencyManager;
            value = PlayerPrefs.GetFloat("attackDamageBuff");
            if (value != null && value > 0) {
                currentLevel = determineLevelFromValue();
            }
        }

        private int determineLevelFromValue() {
            for (int i = 0; i < valueLevels.Length; i++) {
                if (i == valueLevels.Length-1) return i+1;
                if (value >= valueLevels[i]) {
                    if (value < valueLevels[i+1]) {
                        return i+1;
                    }
                }
            }
            return 0;
        }

        private void updateValueStore() {
            PlayerPrefs.SetFloat("attackDamageBuff", value);
        }

        public void LevelUp() {
            if (currencyManager != null) {
                Debug.LogError("currencyManager not found!");
                return;
            }
            if (currentLevel < maxLevel) {
                int tmpNewLevel = currentLevel + 1;
                if (currencyManager.GetBalance() >= costLevels[tmpNewLevel]) {
                    currencyManager.DecreaseBalance(costLevels[tmpNewLevel]);
                    value = valueLevels[tmpNewLevel];
                    updateValueStore();
                    currentLevel = tmpNewLevel;
                } else {
                    Debug.LogError("Cannot afford buff!");
                    return;
                }
            } else {
                Debug.Log("Already max level!");
                return;
            }
        }

        public int GetCurrentLevel() { return currentLevel;}
        public bool CanAffordUpgrade() {
            return currencyManager != null && currencyManager.GetBalance() >= costLevels[currentLevel + 1];
        }
    }

    public class MoveSpeedBuffManager {
        private CurrencyManager currencyManager;
        private int currentLevel = 0;
        private int maxLevel = 4;
        private float value = 0.0f;

        private float[] costLevels = new float[] { 50.0f, 100.0f, 200.0f, 300.0f};
        private float[] valueLevels = new float[] { 2.0f, 6.0f, 14.0f, 20.0f};

        public MoveSpeedBuffManager(CurrencyManager _currencyManager) {
            currencyManager = _currencyManager;
            value = PlayerPrefs.GetFloat("moveSpeedBuff");
            if (value != null && value > 0) {
                currentLevel = determineLevelFromValue();
            }
        }

        private int determineLevelFromValue() {
            for (int i = 0; i < valueLevels.Length; i++) {
                if (i == valueLevels.Length-1) return i+1;
                if (value >= valueLevels[i]) {
                    if (value < valueLevels[i+1]) {
                        return i+1;
                    }
                }
            }
            return 0;
        }

        private void updateValueStore() {
            PlayerPrefs.SetFloat("moveSpeedBuff", value);
        }

        public void LevelUp() {
            if (currencyManager != null) {
                Debug.LogError("currencyManager not found!");
                return;
            }
            if (currentLevel < maxLevel) {
                int tmpNewLevel = currentLevel + 1;
                if (currencyManager.GetBalance() >= costLevels[tmpNewLevel]) {
                    currencyManager.DecreaseBalance(costLevels[tmpNewLevel]);
                    value = valueLevels[tmpNewLevel];
                    updateValueStore();
                    currentLevel = tmpNewLevel;
                } else {
                    Debug.LogError("Cannot afford buff!");
                    return;
                }
            } else {
                Debug.Log("Already max level!");
                return;
            }
        }

        public int GetCurrentLevel() { return currentLevel;}
        public bool CanAffordUpgrade() {
            return currencyManager != null && currencyManager.GetBalance() >= costLevels[currentLevel + 1];
        }
    }

}
