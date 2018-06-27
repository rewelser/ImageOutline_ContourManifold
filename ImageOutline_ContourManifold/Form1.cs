using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
//using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageOutline_ContourManifold {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();


            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\triangle_north.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\circle.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\triangle_sw.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\triangle_ne.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\square.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\square_vert.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\square_diamond.png");

            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\fourpointstar.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\fourpointstar_partial.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\dancer_outline.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\man-shrugs_outline.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\man-standing_outline.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Desktop\bird\frame0.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Desktop\\bird\bird2.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Desktop\frame1.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Desktop\frame2.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Desktop\frame3.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Desktop\frame4.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Desktop\bird\oblong3.png");

            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\triangle_sw.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\triangle_ne.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\sm_tri.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\sm_tri2.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\hull_sm.png");
            Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\dancer_outline.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\man-shrugs_outline.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\vague_circle.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\square_diamond_squashed.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\circle_sm.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\test_dot.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\smalltestshape.png");

            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\tinysquare.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\cat2_inv.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\bigthincircle.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\bigthickoval.png");

            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\testshape_small.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\brutaltest.png");

            Tuple<List<Point>, Point> trace_tuple = CountourTrace(img);
            List<Point> sorted_points = trace_tuple.Item1;
            Point lowXY = trace_tuple.Item2;
            CalcNSDistCtr(ref sorted_points);


            var series = new Series("Distances") {
                ChartType = SeriesChartType.Line
            };


            double[] dists = new double[sorted_points.Count];
            int[] pairInts = new int[sorted_points.Count];

            for (int i = 0; i < sorted_points.Count; i++) {
                //Debug.WriteLine("{" + (points[i].x - 1) + "," + (img.Height - points[i].y) + "} -- " + points[i].ns_dist_center);
                dists[i] = sorted_points[i].ns_dist_center;
                pairInts[i] = i;
            }

            Debug.WriteLine(sorted_points.Count);

            // First parameter is X-Axis and Second is Collection of Y- Axis
            series.Points.DataBindXY(pairInts, dists);
            chart1.Series.Add(series);


            using (StreamWriter writetext = new StreamWriter(@"C:\Users\riwelser\Documents\test_pics\test.csv")) {
                for (int i = 0; i < dists.Length; i++) {
                    writetext.WriteLine(pairInts[i] + "," + dists[i]);
                }
            }
        }


        public void CalcNSDistCtr(ref List<Point> sorted_points) {
            int mean_y = 0;
            int mean_x = 0;
            for (int i = 0; i < sorted_points.Count; i++) {
                mean_x += sorted_points[i].x;
                mean_y += sorted_points[i].y;
            }
            int x_dst = (mean_x / sorted_points.Count);
            int y_dst = (mean_y / sorted_points.Count);

            for (int i = 0; i < sorted_points.Count; i++) {
                sorted_points[i].SetNSDistCenter(new Tuple<int,int>(x_dst, y_dst));
            }
        }

        public Point CalcLowXY(Bitmap img) {
            Point lowXY = null;
            for (int j = img.Height - 1; j > 0; j--) {
                for (int i = 0; i < img.Width; i++) {
                    String htmlColor = "#000000";
                    Color p = img.GetPixel(0, 0);
                    htmlColor = ColorTranslator.ToHtml(img.GetPixel(i, j));
                    if (htmlColor != "#FFFFFF") {
                        lowXY = new Point(i, j, img);
                        return lowXY;
                    }
                }
            }
            return lowXY;
        }
        
        public Tuple<List<Point>, Point> CountourTrace(Bitmap img) {
            List<Point> sorted_points = new List<Point>();
            Point lowXY = CalcLowXY(img);

            Point current = lowXY;
            Tuple<int, int, string> lowXY_tuple = new Tuple<int, int, string>(lowXY.px_x, lowXY.px_y, "#000000");

            // For use with creating testsave.png
            img.SetPixel(current.px_x, current.px_y, Color.Red);

            // Compares tuples based only on first two items (px_x & px_y values)
            bool same_point(Tuple<int, int, string> a, Tuple<int, int, string> b) {
                return (a.Item1 == b.Item1 && a.Item2 == b.Item2);
            }

            int start = 0;
            bool finished = false;
            while (!finished) {

                // Iterate thru current's adjacents, preserving the last direction of movement in start
                for (int i = 0; i < 8; i++) {

                    String htmlColor_this = current.adjacents[start].Item3;
                    String htmlColor_prev = current.adjacents[Mod(start - 1, 8)].Item3;

                    if (htmlColor_this != "#FFFFFF" && htmlColor_prev == "#FFFFFF" && !same_point(current.adjacents[start], lowXY_tuple)) {

                        // For use with creating testsave.png
                        img.SetPixel(current.px_x, current.px_y, Color.Red);

                        sorted_points.Add(current);
                        current = new Point(current.adjacents[start].Item1, current.adjacents[start].Item2, img);
                        start = Mod(start - 1, 8);
                        if (start % 2 == 0) {
                            start = Mod(start - 1, 8);
                        }
                        else {
                            start = Mod(start - 2, 8);
                        }
                        break;
                    }
                    else if (same_point(current.adjacents[start], lowXY_tuple)) {
                        img.SetPixel(current.px_x, current.px_y, Color.Red);
                        finished = true;
                        break;
                    }
                    start = Mod(start + 1, 8);
                }
            }

            // For use with creating testsave.png
            img.Save(@"C:\Users\riwelser\Documents\test_pics\testsave.png");

            return new Tuple<List<Point>, Point>(sorted_points, lowXY);
        }

        public int Mod(int x, int m) {
            return (x % m + m) % m;
        }
    }

    public class Point : IEquatable<Point> {
        public int h, w, px_x, px_y, x, y;
        public double ns_dist_center;
        public List<Tuple<int, int, string>> adjacents = new List<Tuple<int, int, string>>();
        public Point(int px_x, int px_y, Bitmap img) {
            this.h = img.Height;
            this.w = img.Width;
            this.px_x = px_x;
            this.px_y = px_y;
            x = px_x - 1;
            y = h - px_y;

            // Instantiate adjacents in clockwise order around this point:
            adjacents.Add(new Tuple<int, int, string>(px_x - 1, px_y + 1, ColorTranslator.ToHtml(img.GetPixel(px_x - 1, px_y + 1))));   // SW
            adjacents.Add(new Tuple<int, int, string>(px_x - 1, px_y, ColorTranslator.ToHtml(img.GetPixel(px_x - 1, px_y))));       // W
            adjacents.Add(new Tuple<int, int, string>(px_x - 1, px_y - 1, ColorTranslator.ToHtml(img.GetPixel(px_x - 1, px_y - 1))));   // NW
            adjacents.Add(new Tuple<int, int, string>(px_x, px_y - 1, ColorTranslator.ToHtml(img.GetPixel(px_x, px_y - 1))));       // N
            adjacents.Add(new Tuple<int, int, string>(px_x + 1, px_y - 1, ColorTranslator.ToHtml(img.GetPixel(px_x + 1, px_y - 1))));   // NE
            adjacents.Add(new Tuple<int, int, string>(px_x + 1, px_y, ColorTranslator.ToHtml(img.GetPixel(px_x + 1, px_y))));       // E
            adjacents.Add(new Tuple<int, int, string>(px_x + 1, px_y + 1, ColorTranslator.ToHtml(img.GetPixel(px_x + 1, px_y + 1))));   // SE
            adjacents.Add(new Tuple<int, int, string>(px_x, px_y + 1, ColorTranslator.ToHtml(img.GetPixel(px_x, px_y + 1))));       // S
        }

        public void SetNSDistCenter(Tuple<int, int> c) {
            if (c != null) {
                Double dist = Math.Round(Math.Sqrt(Math.Pow((x - c.Item1), 2) + Math.Pow((y - c.Item2), 2)), 2);
                ns_dist_center = Math.Abs(dist);
            }
        }

        public bool Equals(Point other) {
            return (px_x == other.px_x && px_y == other.px_y);
        }

        public bool Equals(Tuple<int, int> other) {
            return (px_x == other.Item1 && px_y == other.Item2);
        }

        public String Print() {
            String text = "{" + px_x + ", " + px_y + "}";
            return text;
        }
    }

}
