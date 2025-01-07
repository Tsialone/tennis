namespace aff
{
    class Dessin : Panel
    {
         private int _circleX = 50;
        private int _circleY = 50;

        public Dessin()
        {
            // Set the panel size and other properties
            this.Size = new Size(300, 300);
            this.BackColor = Color.White;
        }

        // Override the OnPaint method to perform custom drawing
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Get the graphics object
            Graphics g = e.Graphics;

            // Draw a simple circle
            g.FillEllipse(Brushes.Red, _circleX, _circleY, 50, 50);
        }

        // Method to move the circle and trigger repaint
        public void MoveCircle(int dx, int dy)
        {
            _circleX += dx;
            _circleY += dy;
            // Trigger the repaint by calling Invalidate, which forces a call to OnPaint
            this.Invalidate();
        }
    }
}