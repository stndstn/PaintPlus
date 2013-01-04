using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PaintPlus
{
    public abstract class DrawMethod
    {
        public enum DEVICE_TYPE { PEN, BRUSH, IMAGE };
        public enum PEN_TYPE { NOMAL, HEMMED };
        public enum BRUSH_TYPE { SOLID, HATCH, TEXTURE, LINEAR_GRADIENT };
        static protected Color fore_color = Color.Black;
        static protected Color back_color = Color.White;
        static protected Pen pen = new Pen(Color.Black, 3);
        static protected Pen hemmpen = new Pen(Color.White, 5);
        static protected SolidBrush solid_brush = new SolidBrush(Color.Black);
        static protected HatchBrush hatch_brush = new HatchBrush(HatchStyle.Percent05, Color.Black, Color.White);
        static protected TextureBrush texture_brush = new TextureBrush(PaintPlus.Properties.Resources.setup);
        static protected Point ptGradiendStart = Point.Empty;
        static protected Point ptGradiendEnd = Point.Empty;
        static protected Color colorGradiendStart = fore_color;
        static protected Color colorGradiendEnd = back_color;
//        static protected LinearGradientBrush linear_gradient_brush = new LinearGradientBrush(ptGradiendStart, ptGradiendEnd, colorGradiendStart, colorGradiendEnd);
        static protected LinearGradientBrush linear_gradient_brush = null;
        static protected Bitmap device_image_bmp = new Bitmap(32, 32);
        static protected BRUSH_TYPE brushType = BRUSH_TYPE.SOLID;
        static protected PEN_TYPE penType = PEN_TYPE.NOMAL;
        static protected Brush brush = solid_brush;
        static protected Rectangle rcDraw = Rectangle.Empty;
        static protected Region rgDraw = null;
        static protected Point ptStart = Point.Empty;
        static protected Point ptEnd = Point.Empty;
        static int pen_width = 3;
        static int hemm_width = 0;

        //
        // Static Properties
        //
        static public Color DrawColor
        {
            get { return fore_color; }
            set
            {
                fore_color = value;
                pen.Color = fore_color;
                solid_brush.Color = fore_color;
            }
        }
        static public Color BackColor
        {
            get { return back_color; }
            set
            {
                back_color = value;
            }
        }
        static public Image DeviceImage
        {
            get
            {
                return device_image_bmp;
            }
        }
        static public BRUSH_TYPE BrushType
        {
            get { return brushType; }
            set
            {
                brushType = value;
                switch (BrushType)
                {
                    case BRUSH_TYPE.SOLID:
                        brush = solid_brush;
                        break;
                    case BRUSH_TYPE.HATCH:
                        brush = hatch_brush;
                        break;
                    case BRUSH_TYPE.TEXTURE:
                        brush = texture_brush;
                        break;
                    case BRUSH_TYPE.LINEAR_GRADIENT:
                        brush = linear_gradient_brush;
                        break;
                    default:
                        brush = null;
                        break;
                }
                pen.Brush = brush;
            }
        }
        static public PEN_TYPE PenType
        {
            get { return penType; }
            set
            {
                penType = value;
                UpdateDevice();
            }
        }
        static public int PenWidth
        {
            get { return pen_width; }
            set
            {
                pen_width = value;
                UpdateDevice();
            }
        }
        static public int HemmWidth
        {
            get { return hemm_width; }
            set
            {
                hemm_width = value;
                UpdateDevice();
            }
        }

        //
        // static Method
        //
        static public void SetTextureImage(Image img)
        {
            texture_brush.Dispose();
            texture_brush = new TextureBrush(img);
            texture_brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            brush = texture_brush;
        }

        static public void SetHatchStyleColor(HatchStyle style, Color forecolor, Color backcolor)
        {
            hatch_brush.Dispose();
            hatch_brush = new HatchBrush(style, forecolor, backcolor);
            brush = hatch_brush;
        }

        static public void SetGradientColors(Color colorStart, Color colorEnd)
        {
            colorGradiendStart = colorStart;
            colorGradiendEnd = colorEnd;
            if (colorGradiendStart != Color.Empty && colorGradiendEnd != Color.Empty)
            {
                linear_gradient_brush.Dispose();
                linear_gradient_brush = new LinearGradientBrush(ptGradiendStart, ptGradiendEnd, colorGradiendStart, colorGradiendEnd);
                brush = linear_gradient_brush;
            }
        }

        static public void SetGradientLine(Point ptStart, Point ptEnd)
        {
            ptGradiendStart = ptStart;
            ptGradiendEnd = ptEnd;
            if (ptGradiendStart != Point.Empty && ptGradiendEnd != Point.Empty)
            {
                linear_gradient_brush.Dispose();
                linear_gradient_brush = new LinearGradientBrush(ptGradiendStart, ptGradiendEnd, colorGradiendStart, colorGradiendEnd);
                brush = linear_gradient_brush;
            }
        }

        static public void UpdateDevice()
        {
            // device (pen)
            if (pen != null)
            {
                pen.Dispose();
                switch (DrawMethod.brushType)
                {
                    case BRUSH_TYPE.SOLID:
                        pen = new Pen(DrawMethod.DrawColor, DrawMethod.PenWidth);
                        break;
                    default:
                        pen = new Pen(DrawMethod.brush, (float)DrawMethod.PenWidth);
                        break;
                }
            }

            // device image
            Graphics g = Graphics.FromImage(device_image_bmp);
            switch (brushType)
            {
                case BRUSH_TYPE.SOLID:
                    g.FillRectangle(solid_brush, new Rectangle(0, 0, device_image_bmp.Width, device_image_bmp.Height));
                    if (DrawMethod.HemmWidth > 0)
                    {
                        g.DrawRectangle(new Pen(DrawMethod.BackColor, DrawMethod.HemmWidth), new Rectangle(0, 0, device_image_bmp.Width, device_image_bmp.Height));
                    }
                    break;
                case BRUSH_TYPE.HATCH:
                    g.FillRectangle(hatch_brush, new Rectangle(0, 0, device_image_bmp.Width, device_image_bmp.Height));
                    break;
                case BRUSH_TYPE.TEXTURE:
                    g.FillRectangle(texture_brush, new Rectangle(0, 0, device_image_bmp.Width, device_image_bmp.Height));
                    break;
                case BRUSH_TYPE.LINEAR_GRADIENT:
                    LinearGradientBrush tmp_brush = new LinearGradientBrush(new Point(0, 0),
                        new Point(device_image_bmp.Width, device_image_bmp.Height),
                        DrawMethod.colorGradiendStart,
                        DrawMethod.colorGradiendEnd);
                    g.FillRectangle(tmp_brush, new Rectangle(0, 0, device_image_bmp.Width, device_image_bmp.Height));
                    tmp_brush.Dispose();
                    break;
                default:
                    break;
            }
        }

        //
        // virtual Method
        //
        public virtual string GetDrawDeviceName()
        {
            switch (GetDrawDeviceType())
            {
                case DEVICE_TYPE.PEN:
                    return "Pen";
                case DEVICE_TYPE.BRUSH:
                    return "Brush";
                case DEVICE_TYPE.IMAGE:
                    return "Image";
                default:
                    return "";
            }
        }

        public virtual void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e, Image image) 
        {
        }

        public virtual void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e, Image image) 
        {
            ptStart.X = e.X;
            ptStart.Y = e.Y;
            ptEnd = Point.Empty;
        }

        public virtual void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            UpdateImage(sender, image);
        }

        protected virtual void UpdateDrawRect(Point pt)
        {
            Point ptS = Point.Empty;
            if (ptStart.X > pt.X && ptStart.Y > pt.Y)
            {
                ptS = pt;
            }
            else if (ptStart.X < pt.X && ptStart.Y > pt.Y)
            {
                ptS.X = ptStart.X;
                ptS.Y = pt.Y;
            }
            else if (ptStart.X < pt.X && ptStart.Y < pt.Y)
            {
                ptS = ptStart;
            }
            else if (ptStart.X > pt.X && ptStart.Y < pt.Y)
            {
                ptS.X = pt.X;
                ptS.Y = ptStart.Y;
            }
            rcDraw = new Rectangle(ptS.X, ptS.Y, Math.Abs(pt.X - ptStart.X), Math.Abs(pt.Y - ptStart.Y));
        }

        public virtual void UpdateImage(object sender, Image image)
        {
        }

        public void DrawPipe(Graphics g, float width, Point p1, Point p2, Color mid_color, Color edge_color, Control c)
        {
            SizeF along = new SizeF(p2.X - p1.X, p2.Y - p1.Y);
            float mag = (float)Math.Sqrt(along.Width * along.Width + along.Height * along.Height);
            along = new SizeF(along.Width / mag, along.Height / mag);
            SizeF perp = new SizeF(-along.Height, along.Width);

            PointF p1L = new PointF(p1.X + width / 2 * perp.Width, p1.Y + width / 2 * perp.Height);
            PointF p1R = new PointF(p1.X - width / 2 * perp.Width, p1.Y - width / 2 * perp.Height);
            PointF p2L = new PointF(p2.X + width / 2 * perp.Width, p2.Y + width / 2 * perp.Height);
            PointF p2R = new PointF(p2.X - width / 2 * perp.Width, p2.Y - width / 2 * perp.Height);

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(p1.X - (int)width / 2, p1.Y - (int)width / 2, (int)width / 2 * 2, (int)width / 2 * 2));
            gp.AddEllipse(new Rectangle(p2.X - (int)width / 2, p2.Y - (int)width / 2, (int)width / 2 * 2, (int)width / 2 * 2));
            gp.AddLines(new PointF[] { p1, p1L, p2L, p2, p2R, p1R });
            gp.CloseFigure();

            Region region = new Region(gp);
            using (PathGradientBrush brush = new PathGradientBrush(gp))
            {
                brush.CenterColor = mid_color;
                brush.SurroundColors = new Color[]  
                { 
                    edge_color, mid_color, edge_color,edge_color,mid_color,edge_color,edge_color, edge_color
                };
                g.FillRegion(brush, region);
            }
            c.Invalidate(region);
        }
        public void DrawGradienMarble(Graphics g, int rad, Point p1, Color mid_color, Color edge_color)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(p1.X - rad, p1.Y-rad, rad*2, rad*2));
            gp.CloseFigure();
            Region region = new Region(gp);
            using (PathGradientBrush brush = new PathGradientBrush(gp))
            {
                brush.CenterColor = mid_color;
                brush.SurroundColors = new Color[]  
                { 
                    edge_color 
                };
                g.FillRegion(brush, region);
            } 

        }
        
        //
        // abstract Method
        //
        abstract public DEVICE_TYPE GetDrawDeviceType();

    } /* DrawMethod */

    public class FreeDraw : DrawMethod
    {
        static protected Point ptPrev = Point.Empty;
        static List<Point> pt_lines = new List<Point>();

        //
        // abstract Method
        //
        public override  DEVICE_TYPE GetDrawDeviceType() { return DEVICE_TYPE.PEN; }

        //
        // virtual Method
        //
        public override void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            base.OnMouseDown(sender, e, image);

            pt_lines.Clear();
            pt_lines.Add(new Point(e.X, e.Y));
        }

        public override void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pt_lines.Add(new Point(e.X, e.Y));
                Control c = (Control)sender;
                //c.Invalidate(rcDraw);
                //c.Update();
                Graphics g = c.CreateGraphics();
                ptEnd.X = e.X;
                ptEnd.Y = e.Y;

                UpdateDrawRect(new Point(e.X, e.Y));
                Point[] pts = pt_lines.ToArray();
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;
                if (penType == PEN_TYPE.NOMAL)
                {
                    g.DrawLines(pen, pts);
                }
                else if (penType == PEN_TYPE.HEMMED)
                {
                    if (brushType == BRUSH_TYPE.SOLID)
                    {
                        Color pencolor = pen.Color;
                        pen.Color = BackColor;
                        pen.Width = PenWidth + HemmWidth;
                        g.DrawLines(pen, pts);
                        pen.Color = pencolor;
                        pen.Width = PenWidth;
                        g.DrawLines(pen, pts);
                    }
                    else
                    {
                        Pen aPen = new Pen(BackColor, PenWidth + HemmWidth);
                        aPen.StartCap = LineCap.Round;
                        aPen.EndCap = LineCap.Round;
                        aPen.LineJoin = LineJoin.Round;
                        g.DrawLines(aPen, pts);
                        pen.Width = PenWidth;
                        g.DrawLines(pen, pts);
                    }
                }
                g.Dispose();
            }
        }

        public override void UpdateImage(object sender, Image image)
        {
            Control c = (Control)sender;
            Graphics gImg = Graphics.FromImage(image);
            Point[] pts = pt_lines.ToArray();
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            if (penType == PEN_TYPE.NOMAL)
            {
                gImg.DrawLines(pen, pts);
            }
            else if (penType == PEN_TYPE.HEMMED)
            {
                if (brushType == BRUSH_TYPE.SOLID)
                {
                    pen.Color = BackColor;
                    pen.Width = PenWidth + HemmWidth;
                    gImg.DrawLines(pen, pts);
                    pen.Color = DrawColor;
                    pen.Width = PenWidth;
                    gImg.DrawLines(pen, pts);
                }
                else
                {
                    Pen aPen = new Pen(BackColor, PenWidth + HemmWidth);
                    aPen.StartCap = LineCap.Round;
                    aPen.EndCap = LineCap.Round;
                    aPen.LineJoin = LineJoin.Round;
                    gImg.DrawLines(aPen, pts);
                    pen.Width = PenWidth;
                    gImg.DrawLines(pen, pts);
                }
            }
            gImg.Dispose();
            c.Invalidate(rcDraw);
            c.Update();
        }
        protected override void UpdateDrawRect(Point pt)
        {
            Point ptS = Point.Empty;
            if(rcDraw.Contains(pt)) return;

            if (rcDraw.Left > pt.X)
            {
                rcDraw.X = pt.X;
            }
            else if (rcDraw.Right < pt.X)
            {
                rcDraw.Width = pt.X - rcDraw.X;
            }
            if (rcDraw.Top > pt.Y)
            {
                rcDraw.Y = pt.Y;
            }
            else if (rcDraw.Bottom < pt.Y)
            {
                rcDraw.Height = pt.Y - rcDraw.Y;
            }
        }
    } /* FreeDraw */

    public class LineDraw : DrawMethod
    {
        //
        // abstract Method
        //
        public override  DEVICE_TYPE GetDrawDeviceType() { return DEVICE_TYPE.PEN; }

        //
        // virtual Method
        //
        public override  void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            if (ptStart != Point.Empty)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Control c = (Control)sender;
                    //c.Invalidate(rcDraw);
                    c.Invalidate(rgDraw);
                    c.Update();
                    Graphics g = c.CreateGraphics();
                    //UpdateDrawRect(new Point(e.X, e.Y));
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    if (DrawMethod.HemmWidth > 0)
                    {
                        pen.Color = DrawMethod.BackColor;
                        pen.Width = DrawMethod.PenWidth + DrawMethod.HemmWidth;
                        g.DrawLine(pen, ptStart.X, ptStart.Y, e.X, e.Y);
                    }
                    pen.Color = DrawMethod.DrawColor;
                    pen.Width = DrawMethod.PenWidth;
                    g.DrawLine(pen, ptStart.X, ptStart.Y, e.X, e.Y);
                    ptEnd.X = e.X;
                    ptEnd.Y = e.Y;
                    g.Dispose();

                    int width = DrawMethod.PenWidth + DrawMethod.HemmWidth;
                    GraphicsPath gp = new GraphicsPath();
                    Point[] pts = new Point[4];
                    pts[0] = new Point(ptStart.X - width * 2, ptStart.Y - width * 2);
                    pts[1] = new Point(e.X - width * 2, e.Y + width * 2);
                    pts[2] = new Point(e.X + width * 2, e.Y - width * 2);
                    pts[3] = new Point(ptStart.X - width * 2, ptStart.Y + width * 2);
                    gp.AddPolygon(pts);
                    rgDraw = new Region(gp);
                }
            }
        }

        public override  void UpdateImage(object sender, Image image)
        {
            Control c = (Control)sender;
            Graphics gImg = Graphics.FromImage(image);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            if (DrawMethod.HemmWidth > 0)
            {
                pen.Color = DrawMethod.BackColor;
                pen.Width = DrawMethod.PenWidth + DrawMethod.HemmWidth;
                gImg.DrawLine(pen, ptStart.X, ptStart.Y, ptEnd.X, ptEnd.Y);
            }
            pen.Color = DrawMethod.DrawColor;
            pen.Width = DrawMethod.PenWidth;
            gImg.DrawLine(pen, ptStart.X, ptStart.Y, ptEnd.X, ptEnd.Y);
            gImg.Dispose();
            c.Invalidate();
        }
    } /* LineDraw */

    public class RectDraw : DrawMethod
    {
        //
        // abstract Method
        //
        public override  DEVICE_TYPE GetDrawDeviceType() { return DEVICE_TYPE.PEN; }

        //
        // virtual Method
        //
        public override  void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            if (ptStart != Point.Empty)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Control c = (Control)sender;
                    //c.Invalidate(rcDraw);
                    c.Invalidate(rgDraw);
                    c.Update();
                    Graphics g = c.CreateGraphics();
                    UpdateDrawRect(new Point(e.X, e.Y));
                    pen.LineJoin = LineJoin.Round;
                    if (DrawMethod.HemmWidth > 0)
                    {
                        pen.Color = BackColor;
                        pen.Width = PenWidth + HemmWidth;
                        g.DrawRectangle(pen, rcDraw);
                    }
                    pen.Color = DrawColor;
                    pen.Width = PenWidth;
                    g.DrawRectangle(pen, rcDraw);
                    g.Dispose();

                    int width = DrawMethod.PenWidth + DrawMethod.HemmWidth;
                    GraphicsPath gp = new GraphicsPath();
                    Point[] pts1 = new Point[4];
                    pts1[0] = new Point(ptStart.X - width, ptStart.Y - width);
                    pts1[1] = new Point(e.X + width, ptStart.Y - width);
                    pts1[2] = new Point(e.X + width, ptStart.Y + width);
                    pts1[3] = new Point(ptStart.X - width , ptStart.Y + width);
                    gp.AddPolygon(pts1);
                    Point[] pts2 = new Point[4];
                    pts2[0] = new Point(e.X - width, ptStart.Y - width);
                    pts2[1] = new Point(e.X + width, ptStart.Y - width);
                    pts2[2] = new Point(e.X + width, e.Y + width);
                    pts2[3] = new Point(e.X - width, e.Y + width);
                    gp.AddPolygon(pts2);
                    Point[] pts3 = new Point[4];
                    pts3[0] = new Point(ptStart.X - width, e.Y - width);
                    pts3[1] = new Point(e.X + width, e.Y - width);
                    pts3[2] = new Point(e.X + width, e.Y + width);
                    pts3[3] = new Point(ptStart.X - width, ptStart.Y + width);
                    gp.AddPolygon(pts3);
                    Point[] pts4 = new Point[4];
                    pts4[0] = new Point(ptStart.X - width, ptStart.Y - width);
                    pts4[1] = new Point(ptStart.X + width, ptStart.Y - width);
                    pts4[2] = new Point(ptStart.X + width, e.Y + width);
                    pts4[3] = new Point(ptStart.X - width, e.Y + width);
                    gp.AddPolygon(pts3);
                    rgDraw = new Region(gp);
                }
            }
        }
        public override  void UpdateImage(object sender, Image image)
        {
            Control c = (Control)sender;
            Graphics gImg = Graphics.FromImage(image);
            pen.LineJoin = LineJoin.Round;
            if (DrawMethod.HemmWidth > 0)
            {
                pen.Color = BackColor;
                pen.Width = PenWidth + HemmWidth;
                gImg.DrawRectangle(pen, rcDraw);
            }
            pen.Color = DrawColor;
            pen.Width = PenWidth;
            gImg.DrawRectangle(pen, rcDraw);
            gImg.Dispose();
            c.Invalidate();
        }
    } /* RectDraw */

    public class RectFill : RectDraw
    {
        //
        // abstract Method
        //
        public override  DEVICE_TYPE GetDrawDeviceType() { return DEVICE_TYPE.BRUSH; }

        //
        // virtual Method
        //
        public override  void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            UpdateDrawRect(new Point(e.X, e.Y));

            if (DrawMethod.brushType != BRUSH_TYPE.LINEAR_GRADIENT)
            {
                UpdateImage(sender, image);
            }
        }
        public override  void UpdateImage(object sender, Image image)
        {
            Control c = (Control)sender;
            Graphics gImg = Graphics.FromImage(image);
            gImg.FillRectangle(brush, rcDraw);
            gImg.Dispose();
            c.Invalidate();
        }
    } /* RectFill */

    public class FloodFill : DrawMethod
    {
        //
        // abstract Method
        //
        public override  DEVICE_TYPE GetDrawDeviceType() { return DEVICE_TYPE.BRUSH; }

        //
        // virtual Method
        //
        public override void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            Control c = (Control)sender;
            FillFlood(c, new Point(e.X, e.Y), image);
        }
/*
        public override  void UpdateImage(object sender, Image image)
        {
            Control c = (Control)sender;
            Graphics gImg = Graphics.FromImage(image);
            gImg.DrawLine(pen, ptStart.X, ptStart.Y, ptEnd.X, ptEnd.Y);
            gImg.Dispose();
            c.Invalidate();
        }
*/
        protected void FillFlood(Control c, Point node, Image image)
        {
            Color target_color = Color.Empty;
            Color color_of_node = Color.Empty;
            Color replacement_color = Color.Empty;
            Bitmap tmpBmp = new Bitmap(image);

            //Set Q to the empty queue
            System.Collections.Queue q = new System.Collections.Queue();

            //replacement_color is opposite color of node
            try
            {
                target_color = tmpBmp.GetPixel(node.X, node.Y);
                replacement_color = Color.FromArgb(Byte.MaxValue - target_color.R,
                                                    Byte.MaxValue - target_color.G,
                                                    Byte.MaxValue - target_color.B);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                return;
            }

            //Add node to the end of Q
            q.Enqueue(node);

            Graphics gBmp = Graphics.FromImage(image);
            Graphics gTmp = Graphics.FromImage(tmpBmp);

            Pen aPen = new Pen(replacement_color, 1);

            //For each element n of Q
            while (q.Count > 0)
            {
                Point n = (Point)q.Dequeue();

                //If the color of n is not equal to target_color, skip this iteration.
                try
                {
                    color_of_node = tmpBmp.GetPixel(n.X, n.Y);
                    if (color_of_node.Equals(target_color) == false)
                    {
                        continue;
                    }
                }
                catch (ArgumentOutOfRangeException aore)
                {
                    continue;
                }

                //Set w and e equal to n.
                Point w = n;
                Point e = n;

                //Move w to the west until the color of the node w no longer matches target_color.
                Color west_node_color = Color.Empty;
                do
                {
                    try
                    {
                        west_node_color = tmpBmp.GetPixel(--w.X, w.Y);
                    }
                    catch (ArgumentOutOfRangeException aore)
                    {
                        w.X++;
                        break;
                    }
                }
                while (west_node_color.Equals(target_color));

                //Move e to the east until the color of the node e no longer matches target_color.
                Color east_node_color = Color.Empty;
                do
                {
                    try
                    {
                        east_node_color = tmpBmp.GetPixel(++e.X, e.Y);
                    }
                    catch (ArgumentOutOfRangeException aore)
                    {
                        e.X--;
                        break;
                    }
                }
                while (east_node_color.Equals(target_color));

                //Set the color of node s between w and e to replacement_color
                gBmp.DrawLine(pen, w, e);
                gTmp.DrawLine(aPen, w, e);
                c.Invalidate(new Rectangle(w.X, w.Y, e.X - w.X, 1));

                //For each node n2 between w and e.
                int y = w.Y - 1;
                bool isLine = false;
                for (int x = w.X; x <= e.X; x++)
                {
                    //If the color of node at the north of n is target_color, add that node to the end of Q.
                    try
                    {
                        Color test = tmpBmp.GetPixel(x, y);
                        if (tmpBmp.GetPixel(x, y).Equals(target_color))
                        {
                            if (isLine == false)
                            {
                                q.Enqueue(new Point(x, y));
                                isLine = true;
                            }
                        }
                        else
                        {
                            isLine = false;
                        }
                    }
                    catch (ArgumentOutOfRangeException aore)
                    {
                        break;
                    }
                }
                y = w.Y + 1;
                isLine = false;
                for (int x = w.X; x <= e.X; x++)
                {
                    //If the color of node at the north of n is target_color, add that node to the end of Q.
                    try
                    {
                        if (tmpBmp.GetPixel(x, y).Equals(target_color))
                        {
                            if (isLine == false)
                            {
                                q.Enqueue(new Point(x, y));
                                isLine = true;
                            }
                        }
                        else
                        {
                            isLine = false;
                        }
                    }
                    catch (ArgumentOutOfRangeException aore)
                    {
                        break;
                    }
                }
            }/* while */
            aPen.Dispose();
            gBmp.Dispose();
            gTmp.Dispose();
        }/* FillFlood */
    } /* class FloodFill */

    public class DragPastedImage : DrawMethod
    {
        protected Image img_drag = null;
        protected Point ptImageTopLeft = Point.Empty;
        Pen penRim = new Pen(Color.Pink, 4);

        public DragPastedImage(Image img, Point pt)
        {
            img_drag = img;
            ptImageTopLeft = pt;
            rcDraw = new Rectangle(ptImageTopLeft, img_drag.Size);
        }

        public bool isMouseOnTheImage(Point pt)
        {
            return rcDraw.Contains(pt);
        }

        public override DEVICE_TYPE GetDrawDeviceType() { return DEVICE_TYPE.IMAGE; }

        public override void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            ptStart = new Point(e.X, e.Y);
        }

        public override void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            Control c = (Control)sender;
            ptImageTopLeft.X = e.X - ptStart.X;
            ptImageTopLeft.Y = e.Y - ptStart.Y;

            c.Invalidate(rcDraw);
            c.Update();
            rcDraw = new Rectangle(ptImageTopLeft, img_drag.Size);
            using (Graphics g = c.CreateGraphics())
            {
                g.DrawImage(img_drag, ptImageTopLeft);
                g.DrawRectangle(penRim, rcDraw);
            }
        }

        public override void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            ptEnd = new Point(e.X, e.Y);
            UpdateImage(sender, image);
        }

        public override void UpdateImage(object sender, Image image)
        {
            Control c = (Control)sender;
            using (Graphics gBmp = Graphics.FromImage(image))
            {
                gBmp.DrawImage(img_drag, ptImageTopLeft);
                c.Invalidate(rcDraw);
            }
        }
    } /* DragPastedImage */

    public class SelectRectToCopy : RectDraw
    {
        Pen penRim = new Pen(Color.Pink, 4);
        Pen penLast = null;
        public Bitmap bmpToCopy = null;

        //
        // abstract Method
        //
        public override  DEVICE_TYPE GetDrawDeviceType() { return DEVICE_TYPE.IMAGE; }

        //
        // virtual Method
        //
        public override void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            base.OnMouseDown(sender, e, image);
            penLast = pen;
            pen = penRim;
        }

        public override void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            base.OnMouseUp(sender, e, image);
            pen = penLast;
        }

        public override void UpdateImage(object sender, Image image)
        {
            if (bmpToCopy != null)
            {
                bmpToCopy.Dispose();
            }
            bmpToCopy = new Bitmap(rcDraw.Width, rcDraw.Height);
            Graphics gDest = Graphics.FromImage(bmpToCopy);
            gDest.DrawImage(image, new Rectangle(0, 0, rcDraw.Width, rcDraw.Height), rcDraw, GraphicsUnit.Pixel);
            gDest.Dispose();
        }
    } /* SelectRectToCopy */

    public class StringDraw : DrawMethod
    {
        Pen penRim = new Pen(Color.Pink, 4);
        Font font = new Font("Times New Roman", 24);
        String text;
        bool isEdit = false;

        //
        // abstract Method
        //
        public override  DEVICE_TYPE GetDrawDeviceType() { return DEVICE_TYPE.BRUSH; }

        //
        // virtual Method
        //
        public override  void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
        }

        public override  void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e, Image image)
        {
            // 枠がなければ
            if (rcDraw == Rectangle.Empty)
            {
                // 枠を描画
                Control c = (Control)sender;
                using (Graphics g = c.CreateGraphics())
                {
                    rcDraw = new Rectangle(e.X, e.Y, (int)font.Size, (int)font.GetHeight(g));
                    penRim.DashStyle = DashStyle.Dot;
                    g.DrawRectangle(penRim, rcDraw);
                }
            }
            // 枠があれば
            else
            {
                // 枠の外なら
                    // 描画終わり
                    // イメージに転写（UpdateImage）する
                // 枠の中なら
                    // 編集モード
            }
        }

        public override void UpdateImage(object sender, Image image)
        {
            using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                Control c = (Control)sender;
                using (Graphics gBmp = Graphics.FromImage(image))
                {
                    gBmp.DrawString("test", font1, brush, new PointF(0,0));
                    c.Invalidate();
                }
            }
        }
    } /* StringDraw */
}
