namespace Score
{
    public class ScoreModel
    {
        public int Score { get; private set; }
        public void AddScore(int value)
        {
            Score += value;
        }
    }
}
