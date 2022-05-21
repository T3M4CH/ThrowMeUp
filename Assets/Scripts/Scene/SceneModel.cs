using UnityEngine;
namespace Scene
{
    public class SceneModel
    {
        private const string LevelKey = "levelKey";
        public int LevelId { get; private set; }
        public void Initialize()
        {
            LevelId = PlayerPrefs.GetInt(LevelKey, 1);
        }
        public void Save(int value)
        {
            LevelId = value;
            PlayerPrefs.SetInt(LevelKey, LevelId);
        }
    }
}
