using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
namespace Ladder
{
    public class Ladder : Control
    {
        private const int _lineNumAreaWidth = 50;
        private const int _railWidth = 5;
        private const int _minColumn = 10;
        private const int _maxColumnHeight = 50;

        private int _editAreaWidth;
        private int _editAreaHeight;

        private int _numberOfLine;
        private int _numberOfColumn;

        private LadderApperanceModel _apperanceModel;

        #region Properties
        [Browsable(true), Category("Appearance")]
        public LadderApperanceModel AppearanceModel
        {
            set
            {
                _apperanceModel = value;
                Invalidate();
            }
            get { return _apperanceModel; }
        }

        [Browsable(true)]
        public int NumberOfLine
        {
            get
            {
                return _numberOfLine;
            }
            set
            {
                if (value > 0)
                {
                    _numberOfLine = value;
                    Invalidate();
                }
            }
        }
        [Browsable(true)]
        public int NumberOfColumn
        {
            get
            {
                return _numberOfColumn;
            }

            set
            {
                if (value >= _minColumn)
                {
                    _numberOfColumn = value;
                    Invalidate();
                }
            }
        }

        #endregion

        public Ladder()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            AppearanceModel = new LadderApperanceModel();

            _numberOfLine = 10;
            _numberOfColumn = 10;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // [LineNumArea]|| <----ladderArea----> ||
            _editAreaWidth = Width - _lineNumAreaWidth - (2 * _railWidth);
            _editAreaHeight = _maxColumnHeight * _numberOfLine;

            float x = _lineNumAreaWidth + _railWidth;
            int y = 0;

            float cellWidth = _editAreaWidth / _numberOfColumn;

            for (; x <= Width -_railWidth; x +=cellWidth)
            {
                for (; y < Height; y += _maxColumnHeight)
                {
                    Point p = new Point((int)x, y);
                    Cell cell = new Cell();
                    cell.Position = p;
                    cell.width = (int)cellWidth;
                    cell.height = _maxColumnHeight;
                }
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            using (Brush brush = new SolidBrush(AppearanceModel.BackColor))
            {
                pevent.Graphics.FillRectangle(brush, Bounds);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawLineNumberArea(g);
            DrawSrcRail(g);
            DrawEditArea(g);
            DrawDstRail(g);

            base.OnPaint(e);
        }

        private void DrawLineNumberArea(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, _lineNumAreaWidth, Height);
            
            using (Brush backBrush = new SolidBrush(AppearanceModel.LineNumAreaBackColor))
            using (Brush backBrush2 = new LinearGradientBrush(rect, AppearanceModel.LineNumAreaBackColorBegin, AppearanceModel.LineNumAreaBackColorEnd, 0.0f))
            {
                g.FillRectangle(backBrush2, rect);
            }
        }
        private void DrawEditArea(Graphics g)
        {
            GraphicsState state = g.Save();
            g.TranslateTransform(_lineNumAreaWidth + _railWidth, 0.0f);

            int gridWidth = _editAreaWidth / (_numberOfColumn);
            int gridHeight = _maxColumnHeight;

            int editAreaHeight = gridHeight * _numberOfLine;

            using (Pen linePen = new Pen(AppearanceModel.GridColor))
            {
                // vertical line
                Point p1, p2;

                for (int posX = gridWidth; posX < _editAreaWidth; posX += gridWidth)
                {
                    p1 = new Point(posX, 0);
                    p2 = new Point(posX, _editAreaHeight);
                    g.DrawLine(linePen, p1, p2);
                }
                // horizontal line
                for (int yPos = 0; yPos <= _editAreaHeight; yPos += gridHeight)
                {
                    p1 = new Point(0, yPos);
                    p2 = new Point(_editAreaWidth, yPos);
                    g.DrawLine(linePen, p1, p2);
                }
            }

            g.Restore(state);

        }
        private void DrawSrcRail(Graphics g)
        {
            GraphicsState state = g.Save();
            g.TranslateTransform(_lineNumAreaWidth, 0.0f);
            using (Brush brush = new SolidBrush(AppearanceModel.RailColor))
            {
                Rectangle rect = new Rectangle(0, 0, _railWidth, Height);
                g.FillRectangle(brush, rect);
            }
            g.Restore(state);
        }
        private void DrawDstRail(Graphics g)
        {
            GraphicsState state = g.Save();
            g.TranslateTransform(_lineNumAreaWidth, 0.0f);
            using (Brush brush = new SolidBrush(AppearanceModel.RailColor))
            {
                int startX = _railWidth + _editAreaWidth;
                Rectangle rect = new Rectangle(startX, 0, _railWidth, Height);
                g.FillRectangle(brush, rect);
            }
            g.Restore(state);
        }

        #region Code related to Mouse event
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point location = e.Location;
            
            
        }
        #endregion

        #region Code related to Drag&Drop
        protected override void OnDragEnter(DragEventArgs e)
        {
            // drag 중 화면 표시 변경
            if (e.Data.GetDataPresent(typeof(ElementType)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drgevent"></param>
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            // element를 추가한다
            ElementType? data = drgevent.Data.GetData(typeof(ElementType)) as ElementType?;

            if (data == null)
            {
                return;
            }

            ElementType type = data.Value;
            Point dragPosition = PointToClient(new Point(drgevent.X, drgevent.Y));
            string text = string.Empty;
            switch (type)
            {
                case ElementType.NormalContact: text = "normal"; break;
                case ElementType.ClosedContact: text = "closed"; break;
                case ElementType.Coil: text = "coil"; break;
                default: text = "non select"; break;
            }
            MessageBox.Show(text);
        }

        #endregion
    }
    
    public struct Cell
    {
        public Point Position;
        public Rectangle Bounds;
        public int x;
        public int y;
        public int width;
        public int height;
        
        public Cell(Point p, Rectangle rect, int x, int y, int width, int height)
        {
            this.Position = p;
            this.Bounds = rect;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }


}
