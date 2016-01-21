using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllib.Graphic;
namespace Controllib.Controls
{
    public class StemItem
    {
        public enum Step
        {
            PROGRASS,
            FAIL,
            SUCCESS,
            DEFAULT
        }

        private Color _defaultColor = Color.FromArgb(255, 100, 100, 100);
        private Color _failedColor = Color.FromArgb(255, 255, 0, 0);
        private Color _successedColor = Color.FromArgb(255, 0, 255, 0);
        private Color _progressColor = Color.FromArgb(255, 0, 0, 255);

        public string Text { set; get; }

        public Step Active { set; get; }

        public StemItem()
        {
            Text = string.Empty;
        }

        public void Draw(Graphics g, Rectangle bounds)
        {

        }

        private Color ActiveColor(Step step)
        {
            switch (step)
            {
                case Step.PROGRASS: return _progressColor;
                case Step.SUCCESS: return _successedColor;
                case Step.FAIL: return _failedColor;
                default: return _defaultColor;
            }
        }
    }

    public class StepControl : Control
    {
        private readonly float RoundBoxRadius = 3.0f;

        #region fields 

        // graphics fields

        #endregion

        #region properties

        private Color _defaultColor;
        private Color _failedColor;
        private Color _successedColor;

        #endregion

        public StepControl()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle(3, 3, 100, 100);
            PaintStepBox(g, rect);
        }

        private void PaintStepBox(Graphics g, Rectangle bounds)
        {
            //g.FillRoundRect()

            using (Brush brush = new SolidBrush(Color.White))
            {
                g.FillRoundRect(brush, bounds, RoundBoxRadius);
            }
        }
    }
}
