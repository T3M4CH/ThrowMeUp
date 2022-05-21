namespace Score
{
    public class ScoreInteractor
    {
        private ScoreModel _scoreModel;
        private float _heightRecord = 1;
        public ScoreInteractor(ScoreModel model)
        {
            _scoreModel = model;
        }
        public void CommitPosition(float playerPosition)
        {
            if (playerPosition <= _heightRecord) return;
            _scoreModel.AddScore(playerPosition - _heightRecord > 4 ? 30 : 15);
            _heightRecord = playerPosition;
        }
    }
}