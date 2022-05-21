namespace Scene
{
    public class SceneInteractor
    {
        private SceneModel _sceneModel;
        public int LevelId => _sceneModel.LevelId;
        public SceneInteractor(SceneModel sceneModel)
        {
            _sceneModel = sceneModel;
        }
        public void AddLevel()
        {
            _sceneModel.Save(LevelId + 1);
        }
    }
}