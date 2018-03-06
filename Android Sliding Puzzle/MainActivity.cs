using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System;
using Android.Views;
using System.Collections;

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

        ArrayList tilesArr;
        ArrayList coordsArr;

        Point emptySpot;

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            setGameView();

            makeTilesMethod();

            randomizeMethod();
        }

        private void makeTilesMethod()
        {
            tileWidth = gameViewWidth / 4;

            tilesArr = new ArrayList();
            coordsArr = new ArrayList();

            int counter = 1;
            for (int h = 0; h < 4; h++)
            {
                for (int v = 0; v < 4; v++)
                {
                    MyTextView textTile = new MyTextView(this);

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
                    textTile.SetBackgroundColor(Color.LightGreen);

                    Point thisLoc = new Point(v, h);
                    coordsArr.Add(thisLoc);

                    textTile.xPos = thisLoc.X;
                    textTile.yPos = thisLoc.Y;

                    textTile.Touch += TextTile_Touch;

                    tilesArr.Add(textTile);

                    mainLayout.AddView(textTile);

                    counter++;
                }
            }

            mainLayout.RemoveView((MyTextView) tilesArr[15]);
            tilesArr.RemoveAt(15);
        }

        void TextTile_Touch(object sender, View.TouchEventArgs e)
        {
            if(e.Event.Action == MotionEventActions.Up)
            {
                if(tilesArr.Contains(sender))
                {
                    MyTextView thisTile = (MyTextView) sender;

                    Console.WriteLine("Tile Position X:{0} -- Y:{1}", thisTile.xPos, thisTile.yPos);
                    Console.WriteLine("Empty Position X:{0} -- Y:{1}", emptySpot.X, emptySpot.Y);

                }
            }
        }

        private void randomizeMethod()
        {
            ArrayList tempCoords = new ArrayList(coordsArr);

            Random myRand = new Random();

            foreach (MyTextView any in tilesArr)
            {
                int randIndex = myRand.Next(0, tempCoords.Count);
                Point thisRandLoc = (Point) tempCoords[randIndex];

                GridLayout.Spec rowSpec = GridLayout.InvokeSpec(thisRandLoc.Y);
                GridLayout.Spec colSpec = GridLayout.InvokeSpec(thisRandLoc.X);

                GridLayout.LayoutParams randLayoutParam = new GridLayout.LayoutParams(rowSpec, colSpec);

                any.xPos = thisRandLoc.X;
                any.yPos = thisRandLoc.Y;

                randLayoutParam.Width = tileWidth - 10;
                randLayoutParam.Height= tileWidth - 10;
                randLayoutParam.SetMargins(5, 5, 5, 5);

                any.LayoutParameters = randLayoutParam;

                tempCoords.RemoveAt(randIndex);
            }
            emptySpot = (Point) tempCoords[0];
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
            randomizeMethod();
        }
    }

    class MyTextView : TextView
    {
        Activity myContext;

        public MyTextView(Activity context) : base(context)
        {
            myContext = context;
        }

        public int xPos { set; get; }
        public int yPos { set; get; }
    }
}

