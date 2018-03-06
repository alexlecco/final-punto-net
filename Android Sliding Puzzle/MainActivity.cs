using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System;

namespace Android_Sliding_Puzzle
{
    [Activity(Label = "Android_Sliding_Puzzle", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        Button resetButton;
        GridLayout mainLayout;

        int gameViewWidth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            setGameView();
        }

        private void setGameView()
        { 
            resetButton = FindViewById<Button>(Resource.Id.resetButtonId);
            resetButton.Click += resetMethod;

            mainLayout = FindViewById<GridLayout>(Resource.Id.gameGridLayoutId);
            gameViewWidth = Resources.DisplayMetrics.WidthPixels;

            mainLayout.ColumnCount = 4;
            mainLayout.RowCount = 4;

            mainLayout.LayoutParameters = new LinearLayout.LayoutParams(gameViewWidth, gameViewWidth);
            mainLayout.SetBackgroundColor(Color.Gray);

        }
        
        private void resetMethod(object sender, EventArgs e)
        {
            
        }
    }
}

