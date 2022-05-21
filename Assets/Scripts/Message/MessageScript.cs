using System;
namespace UI
{
    public class MessageScript : IDisposable
    {
        private BoolChannel _boolChannel;
        private MessagePanel _panel;
        public MessageScript(BoolChannel boolChannel, MessagePanel panel)
        {
            _boolChannel = boolChannel;
            _panel = panel;
            _boolChannel.AddListener(SetWindow);
            _panel.gameObject.SetActive(false);
        }
        private void SetWindow(bool winner)
        {
            _panel.gameObject.SetActive(true);
            if (winner)
            {
                _panel.Text.text = "You're winner!";
                _panel.ButtonText.text = "Next Level";
            }
            else
            {
                _panel.Text.text = "Shit happens :(";
                _panel.ButtonText.text = "Same level";
            }
        }
        public void Dispose()
        {
            _boolChannel.RemoveListener(SetWindow);
        }
    }
}
