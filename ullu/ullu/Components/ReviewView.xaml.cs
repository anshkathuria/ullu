
using ullu.Models;
using Xamarin.Forms;

namespace ullu.Components
{
    public partial class ReviewView : ContentView
    {
        Review r;
        Image i;
        public ReviewView()
        {
            InitializeComponent();
            

        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            r = this.BindingContext as Review;
            if (r != null)
            {
                ratingWrapper.Children.Clear();
                for (int k = 0; k < r.Rating; k++)
                    ratingWrapper.Children.Add(new Image { Source = FileImageSource.FromFile("star_selected.png") });
            }
        }
    }
}
