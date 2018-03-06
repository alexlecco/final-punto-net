using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System;
using Android.Views;

namespace Android_Sliding_Puzzle
{
    [Activity(Label = "Android_Sliding_Puzzle", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region vars

        Button resetButton;
        GridLayout mainLayout;

        int gameViewWidth;
        int tileWidth;

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            setGameView();

            makeTilesMethod();
        }

        private void makeTilesMethod()
        {
            tileWidth = gameViewWidth / 4;

            int counter = 1;
            for (int h = 0; h < 4; h++)
            {
                for (int v = 0; v < 4; v++)
                {
                    TextView textTile = new TextView(this);

                    GridLayout.Spec rowSpec = GridLayout.InvokeSpec(h);
                    GridLayout.Spec colSpec = GridLayout.InvokeSpec(v);

                    GridLayout.LayoutParams tileLayoutParams = new GridLayout.LayoutParams(rowSpec, colSpec);

                    textTile.Text = counter.ToString();
                    textTile.SetTextColor(Color.Black);
                    textTile.TextSize = 40;
                    textTile.Gravity = GravityFlags.Center;

                    tileLayoutParams.Width = tileWidth - 10;
                    tileLayoutParams.Height = tileWidth - 10;
                    tileLayoutParams.SetMargins(5, 5, 5, 5);

                    textTile.LayoutParameters = tileLayoutParams;
                    textTile.SetBackgroundColor(Color.Green);

                    mainLayout.AddView(textTile);

                    counter++;
                }
            }
            
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
        
        void resetMethod(object sender, EventArgs e)
        {
            
        }
    }
}

