using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Drawing;
//using System.Drawing.Imaging;
//using System.IO;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;

namespace ImageOutline_ContourManifold {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            List<Point> points = new List<Point>();
            //List<Pair> pairs = new List<Pair>();


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
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\dancer_outline.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\man-shrugs_outline.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\vague_circle.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\square_diamond_squashed.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\circle_sm.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\test_dot.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\smalltestshape.png");

            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\tinysquare.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\cat2_inv.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\bigthincircle.png");
            Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\bigthickoval.png");

            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\testshape_small.png");
            //Bitmap img = new Bitmap(@"C:\Users\riwelser\Documents\test_pics\brutaltest.png");
            CountourTrace(img);

            //int start = 3;
            //for (int i = 0; i < 8; i++) {

            //    Debug.WriteLine(start);
            //    start = Mod(start + 1, 8);

            //    if (start == 1) {
            //        break;
            //    }
            //}

            //for (int i = 0; i < img.Width; i++) {
            //    for (int j = 0; j < img.Height; j++) {
            //        Color pixel = img.GetPixel(i, j);
            //        int h = img.Height;
            //        int w = img.Width;
            //        int x = i + 1;
            //        int y = (h - j);
            //        String htmlColor = ColorTranslator.ToHtml(pixel);


            //        if (htmlColor != "#FFFFFF") {
            //            Point p = new Point(x, y);
            //            points.Add(p);
            //        }
            //    }
            //}

            //CountourTrace(img, points);


            /*

            ///// SUPPOSED to be from center point dist
            int mean_y = 0;
            int mean_x = 0;
            for (int i = 0; i < points.Count; i++) {
                mean_x += points[i].x;
                mean_y += points[i].y;
            }

            Point ctr = new Point(mean_x / points.Count, mean_y / points.Count);

            // Find lowXY of points
            Point lowXY = points[0];
            for (int i = 0; i < points.Count; i++) {
                if (points[i].y < lowXY.y || (points[i].y == lowXY.y && points[i].x < lowXY.x)) {
                    lowXY = points[i];
                }
            }

            // Moore-Neighbor boundary tracing (using the pre-existing adjacents table held by each pixel)
            Point current = lowXY;
            Point prospective_current = null;

            //Debug.WriteLine(lowXY.adjacents[2].Print());
            //Debug.WriteLine(lowXY.adjacents[0].Print());
            //Debug.WriteLine(points.Contains(lowXY.adjacents[2]));
            //Debug.WriteLine(lowXY.adjacents[2].Equals(points[15]));
            List<Point> visited = new List<Point>();
            Stack<Point> visit_stack = new Stack<Point>();
            //Debug.WriteLine(lowXY.Print());
            Debug.WriteLine("{" + (lowXY.x - 1) + "," + (img.Height - lowXY.y) + "}");
            Debug.WriteLine("++++++");
            for (int i = 0; i < points.Count; i++) {

                //Debug.WriteLine("{" + (current.x - 1) + "," + (img.Height - current.y) + "}");
                //Debug.WriteLine("- - - -");
                for (int j = 0; j < current.adjacents.Count; j++) {
                    if ((current.x == 4 && current.y == 66) || (current.x == 3 && current.y == 66)) {
                        //Debug.WriteLine(current.adjacents[j].Print());
                        //Debug.WriteLine("{" + (current.adjacents[j].x - 1) + "," + (img.Height - current.adjacents[j].y) + "}");
                    }
                    
                    if (points.Contains(current.adjacents[j]) && !visited.Contains(current.adjacents[j]) && !points.Contains(current.adjacents[Mod(j - 1, current.adjacents.Count)])) {
                        if (prospective_current == null) {
                            prospective_current = points[points.IndexOf(current.adjacents[j])];
                        }
                    }
                }
                //if (current.adjacents.Contains(lowXY) ) {
                //    i = points.Count;
                //}
                if (!visited.Contains(current)) {
                    current.SetNSDistCenter(ctr);
                    //current.SetNSDistCenter(lowXY);
                    visited.Add(current);
                    img.SetPixel(current.x - 1, img.Height - current.y, Color.Red);

                }
                if (prospective_current == null) {
                    current = visit_stack.Pop();
                } else {
                    visit_stack.Push(current);
                    current = prospective_current;
                    prospective_current = null;
                }
                //Debug.WriteLine("()()()()()");
            }
            img.Save(@"C:\Users\riwelser\Documents\test_pics\testsave.png");


            Debug.WriteLine("----");

            for (int i = 0; i < visited.Count; i++) {
                //Debug.WriteLine(visited[i].Print());
                //Debug.WriteLine("{" + (visited[i].x - 1) + "," + (img.Height - visited[i].y) + "}");
            }

            //Debug.WriteLine(points.Count);
            //Debug.WriteLine(visited.Count);
            Debug.WriteLine(points.Count == visited.Count);

            points = visited;

            // After, the rest below should be the same--just that the points array is now sorted in a counter-clockwise fashion.

            var series = new Series("Finance") {
                ChartType = SeriesChartType.Line
            };


            double[] dists = new double[points.Count];
            int[] pairInts = new int[points.Count];

            for (int i = 0; i < points.Count; i++) {
                //Debug.WriteLine("{" + (points[i].x - 1) + "," + (img.Height - points[i].y) + "} -- " + points[i].ns_dist_center);
                dists[i] = points[i].ns_dist_center;
                pairInts[i] = i;
            }

            Debug.WriteLine(points.Count);

            // First parameter is X-Axis and Second is Collection of Y- Axis
            series.Points.DataBindXY(pairInts, dists);
            chart1.Series.Add(series);


            using (StreamWriter writetext = new StreamWriter(@"C:\Users\riwelser\Documents\test_pics\test.csv")) {
                for (int i = 0; i < dists.Length; i++) {
                    writetext.WriteLine(pairInts[i] + "," + dists[i]);
                }
            }
            */
        }

        public Point GetLowXY(Bitmap img) {
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

        public List<Point> CountourTrace(Bitmap img) {
            List<Point> sorted_points = new List<Point>();
            Point lowXY = GetLowXY(img);
            Point current = lowXY;
            img.SetPixel(current.px_x, current.px_y, Color.Red);
            Tuple<int, int, string> lowXY_tuple = new Tuple<int, int, string>(lowXY.px_x, lowXY.px_y, "#000000");
            bool finished = false;
            bool same_point(Tuple<int, int, string> a, Tuple<int, int, string> b) {
                return (a.Item1 == b.Item1 && a.Item2 == b.Item2);
            }

            // trying to rework so that the direction of entry is preserved in the start variable
            int start = 0;
            while (!finished) {
                //Debug.WriteLine(start);
                //Debug.WriteLine(current.Print());
                for (int i = 0; i < 8; i++) {

                    //Debug.WriteLine(start + ", " );
                    //Debug.WriteLine(current.adjacents[start].Item1 + "," + current.adjacents[start].Item2);
                    String htmlColor_this = current.adjacents[start].Item3;
                    String htmlColor_prev = current.adjacents[Mod(start - 1, 8)].Item3;

                    // to test: 
                    if (current.adjacents[start].Item1 == lowXY_tuple.Item1 && current.adjacents[start].Item2 == lowXY_tuple.Item2) {
                        //Debug.WriteLine("HERE");
                        //Debug.WriteLine(current.adjacents[start].Equals(lowXY_tuple));
                        //Debug.WriteLine(current.adjacents[start].Item3 + ", " + lowXY_tuple.Item3);
                    }

                    if (htmlColor_this != "#FFFFFF" && htmlColor_prev == "#FFFFFF" && !same_point(current.adjacents[start], lowXY_tuple)) {
                        //Debug.WriteLine("Added: " + current.adjacents[start].Item1 + "," + current.adjacents[start].Item2);
                        img.SetPixel(current.px_x, current.px_y, Color.Red);

                        sorted_points.Add(current);
                        current = new Point(current.adjacents[start].Item1, current.adjacents[start].Item2, img);
                        //Debug.Write("modified start: " + start + " - 1 --> ");
                        start = Mod(start - 1, 8);

                        if (start % 2 == 0) {
                            start = Mod(start - 1, 8);
                        }
                        else {
                            start = Mod(start - 2, 8);
                        }
                        //Debug.WriteLine(start);
                        break;
                    }
                    else if (same_point(current.adjacents[start], lowXY_tuple)) {
                        img.SetPixel(current.px_x, current.px_y, Color.Red);
                        finished = true;
                        break;
                    }
                    //Debug.WriteLine("modified start: " + start + " --> " + Mod(start + 1, 8));
                    start = Mod(start + 1, 8);
                }
            }


            img.Save(@"C:\Users\riwelser\Documents\test_pics\testsave.png");

            //while (lowXY.h != 9) {
            //    if (current.adjacents.Count > 0) {
            //        img.SetPixel(current.px_x, current.px_y, Color.Red);
            //        current = new Point(current.adjacents[0].Item1, current.adjacents[0].Item2, img);
            //    }
            //    for (int i = 0; i < current.adjacents.Count; i++) {

            //    }
            //    if ()
            //}


            //while (/*some condition*/) {
            //    int start = 0;
            //    int adjs = current.adjacents.Count;
            //    for (int i = start; Mod(i, adjs) < adjs; i++) {
            //        String htmlColor_this = ColorTranslator.ToHtml(img.GetPixel(current.adjacents[i].Item1, current.adjacents[i].Item2));
            //        String htmlColor_prev = ColorTranslator.ToHtml(img.GetPixel(current.adjacents[Mod(i - 1, current.adjacents.Count)].Item1, current.adjacents[Mod(i - 1, current.adjacents.Count)].Item2));
            //    }
            //}

            //Point test = new Point(3, 5, img);
            ////test = lowXY;
            //for (int i = 0; i < test.adjacents.Count; i++) {
            //    Debug.WriteLine(test.adjacents[i].Item1 + ", " + test.adjacents[i].Item2);
            //}

            //img.SetPixel(test.px_x, test.px_y, Color.Red);
            //img.Save(@"C:\Users\riwelser\Documents\test_pics\testsave.png");

            //for (int i = 0; i < img.Width; i++) {
            //    for (int j = 0; j < img.Height; j++) {
            //        Color pixel = img.GetPixel(i, j);
            //        int h = img.Height;
            //        int w = img.Width;
            //        int x = i + 1;
            //        int y = (h - j);
            //        String htmlColor = ColorTranslator.ToHtml(pixel);


            //        if (htmlColor != "#FFFFFF") {
            //            Point p = new Point(x, y);
            //            points.Add(p);
            //        }
            //    }
            //}

            /*
            int mean_y = 0;
            int mean_x = 0;
            Point lowXY = unsorted_points[0];
            for (int i = 0; i < unsorted_points.Count; i++) {

                // Calculate means necessary to find central point
                mean_x += unsorted_points[i].x;
                mean_y += unsorted_points[i].y;

                // Find lowXY of unsorted_points
                if (unsorted_points[i].y < lowXY.y || (unsorted_points[i].y == lowXY.y && unsorted_points[i].x < lowXY.x)) {
                    lowXY = unsorted_points[i];
                }
            }

            Point ctr = new Point(mean_x / unsorted_points.Count, mean_y / unsorted_points.Count);

            

            Point current = lowXY;
            Point prospective = null;
            List<Point> visited = new List<Point>();
            while(!visited.Contains(lowXY)) {
                for (int j = 0; j < current.adjacents.Count; j++) {
                    string adj_pre_clr = ColorTranslator.ToHtml(img.GetPixel(current.adjacents[j].x - 1, img.Height - current.adjacents[j].y));
                    string adj_aft_clr = ColorTranslator.ToHtml(img.GetPixel(current.adjacents[Mod(j-1, current.adjacents.Count)].x - 1, img.Height - current.adjacents[Mod(j - 1, current.adjacents.Count)].y));
                    if (prospective == null && !visited.Contains(current.adjacents[j]) && adj_pre_clr == "#000000" && adj_aft_clr == "#FFFFFF") {
                        Debug.WriteLine(current.adjacents[j].Print());
                        prospective = current.adjacents[j];
                        prospective = unsorted_points[unsorted_points.IndexOf(current.adjacents[j])];
                    }
                    
                    
                }
                Debug.WriteLine("cur("+current.Print()+")");
                Debug.WriteLine("pro("+prospective.Print()+")");
                Debug.WriteLine("---");
                current = prospective;
                visited.Add(prospective);
                img.SetPixel(prospective.x - 1, img.Height - prospective.y, Color.Red);
                prospective = null;
            }
            Debug.WriteLine("got here");
            Debug.WriteLine(lowXY.Print());
            Debug.WriteLine(visited[0].Print());
            img.Save(@"C:\Users\riwelser\Documents\test_pics\testsave.png");

            
            */

            return sorted_points;
        }

        public int Mod(int x, int m) {
            return (x % m + m) % m;
        }

        //public int Angle_Selection_Sort () {
        //    return 3;
        //}




    }

    public class Point : IEquatable<Point> {
        public int h, w, px_x, px_y, x, y;
        public double ns_dist_center;
        //public List<Point> adjacents;
        public List<Tuple<int, int, string>> adjacents = new List<Tuple<int, int, string>>();
        public Point(int px_x, int px_y, Bitmap img) {
            this.h = img.Height;
            this.w = img.Width;
            this.px_x = px_x;
            this.px_y = px_y;
            x = px_x - 1;
            y = h - px_y;

            // Instantiate adjacents in clockwise order around this point:
            // SW, W, NW, N, NE, E, SE, S
            //adjacents.Add(new Tuple<int, int>(px_x - 1, px_y - 1));   // SW // NW
            //adjacents.Add(new Tuple<int, int>(px_x - 1, px_y));       // W  // W
            //adjacents.Add(new Tuple<int, int>(px_x - 1, px_y + 1));   // NW // SW
            //adjacents.Add(new Tuple<int, int>(px_x, px_y + 1));       // N  // S
            //adjacents.Add(new Tuple<int, int>(px_x + 1, px_y + 1));   // NE // SE
            //adjacents.Add(new Tuple<int, int>(px_x + 1, px_y));       // E  // E
            //adjacents.Add(new Tuple<int, int>(px_x + 1, px_y - 1));   // SE // NE
            //adjacents.Add(new Tuple<int, int>(px_x, px_y - 1));       // S  // N

            adjacents.Add(new Tuple<int, int, string>(px_x - 1, px_y + 1, ColorTranslator.ToHtml(img.GetPixel(px_x - 1, px_y + 1))));   // NW // SW
            adjacents.Add(new Tuple<int, int, string>(px_x - 1, px_y, ColorTranslator.ToHtml(img.GetPixel(px_x - 1, px_y))));       // W  // W
            adjacents.Add(new Tuple<int, int, string>(px_x - 1, px_y - 1, ColorTranslator.ToHtml(img.GetPixel(px_x - 1, px_y - 1))));   // SW // NW
            adjacents.Add(new Tuple<int, int, string>(px_x, px_y - 1, ColorTranslator.ToHtml(img.GetPixel(px_x, px_y - 1))));       // S  // N
            adjacents.Add(new Tuple<int, int, string>(px_x + 1, px_y - 1, ColorTranslator.ToHtml(img.GetPixel(px_x + 1, px_y - 1))));   // SE // NE
            adjacents.Add(new Tuple<int, int, string>(px_x + 1, px_y, ColorTranslator.ToHtml(img.GetPixel(px_x + 1, px_y))));       // E  // E
            adjacents.Add(new Tuple<int, int, string>(px_x + 1, px_y + 1, ColorTranslator.ToHtml(img.GetPixel(px_x + 1, px_y + 1))));   // NE // SE
            adjacents.Add(new Tuple<int, int, string>(px_x, px_y + 1, ColorTranslator.ToHtml(img.GetPixel(px_x, px_y + 1))));       // N  // S

            //List<Tuple<int, int>> temp_adjs = new List<Tuple<int, int>>();
            //for (int i = 0; i < adjacents.Count; i++) {
            //    String htmlColor_this = ColorTranslator.ToHtml(img.GetPixel(adjacents[i].Item1, adjacents[i].Item2));
            //    String htmlColor_prev = ColorTranslator.ToHtml(img.GetPixel(adjacents[Mod(i-1, adjacents.Count)].Item1, adjacents[Mod(i - 1, adjacents.Count)].Item2));
            //    if (htmlColor_this != "#FFFFFF" && htmlColor_prev == "#FFFFFF") {
            //        temp_adjs.Add(adjacents[i]);
            //    }
            //}
            //adjacents = temp_adjs;
        }

        public Point(int x, int y, Point center) {
            this.x = x;
            this.y = y;
            SetNSDistCenter(center);
        }

        public int Mod(int x, int m) {
            return (x % m + m) % m;
        }

        public void SetNSDistCenter(Point c) {
            if (c != null) {
                Double dist = Math.Round(Math.Sqrt(Math.Pow((x - c.x), 2) + Math.Pow((y - c.y), 2)), 2);
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
