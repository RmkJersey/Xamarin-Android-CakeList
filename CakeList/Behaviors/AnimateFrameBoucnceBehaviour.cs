using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CakeList.Behaviors
{
    public class AnimateFrameBoucnceBehaviour : Behavior<Frame>
    {
        protected override void OnAttachedTo(Frame bindable)
        {
            bindable.PropertyChanged += Bindable_PropertyChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Frame bindable)
        {
            bindable.PropertyChanged -= Bindable_PropertyChanged;
            base.OnDetachingFrom(bindable);
        }

        bool _isAnimating;
        private void Bindable_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Parent")
                return;

            if (_isAnimating)
                return;

            _isAnimating = true;

            var bindable = (Element)sender;

            if (!(bindable is Frame frame))
                return;

            frame.Opacity = 0;
            frame.TranslationY = 200;

            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await Task.WhenAll(
                        frame.FadeTo(1, 500, Easing.Linear),
                        frame.TranslateTo(0, 0, 800, Easing.SpringOut)
                    );
                }
                finally
                {
                    _isAnimating = false;
                }
            });
        }
    }
}
