using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maxit_Single_Player
{
    public partial class FormMain : Form
    {
        private int _turnCounter, _score, _currentRow, _currentColumn, _positiveCounter, _negativeCounter;
        private PictureBox pictureBox;
        private GameLabel[,] _elements;

        public FormMain()
        {
            InitializeComponent();
            InitializeButtons();

            _score = 0;
            _turnCounter = 0;
            _positiveCounter = 0;
            _negativeCounter = 0;

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true); // в конструкторе

            pictureBox = new PictureBox
            {
                Location = new Point(0, 0),
                Size = new Size(1000, 1000),
                BackColor = Color.Transparent
            };

            Pen pen = new Pen(Color.Black);
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(pen, 10, 10, 100, 100);
            formGraphics.DrawRectangle(pen, new Rectangle(10, 10, 600, 600));
            pen.Dispose();
            formGraphics.Dispose();

        }

        public void InitializeButtons()
        {
            _elements = new GameLabel[4, 4] {
                { new GameLabel(0,0, label1), new GameLabel(0,1, label2), new GameLabel(0,2, label3), new GameLabel(0,3, label4)},
                { new GameLabel(1,0, label5), new GameLabel(1,1, label6), new GameLabel(1,2, label7), new GameLabel(1,3,label8)},
                { new GameLabel(2,0, label9), new GameLabel(2,1, label10), new GameLabel(2,2, label11), new GameLabel(2,3, label12)},
                { new GameLabel(3,0, label13), new GameLabel(3,1, label14), new GameLabel(3,2, label15), new GameLabel(3,3, label16)}
            };

            Random random = new Random();
            int value;
            foreach (GameLabel elem in _elements)
            {
                bool repeat;
                do
                {
                    value = random.Next(-10, +10);

                    if (value > 0 && _positiveCounter >= _elements.Length / 2 && _negativeCounter != _elements.Length / 2 ||
                        value < 0 && _negativeCounter >= _elements.Length / 2 && _positiveCounter != _elements.Length / 2)
                    {
                        repeat = true;
                    } 
                    else
                    {
                        repeat = false;
                        _ = value > 0 ? _positiveCounter++ : _negativeCounter++;
                    }
                } while (value == 0 || repeat);

                elem.Label.Text = value.ToString();
                elem.Label.ForeColor = value > 0 ? Color.Red : Color.Blue;
                elem.Label.Font = new Font(FontFamily.GenericSansSerif, 26);
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            int tempScore = Convert.ToInt32((sender as Label).Text);

            GameLabel currentGameLabel = new GameLabel();
            foreach (GameLabel gameElem in _elements)
            {
                if (gameElem.Label == sender as Label)
                {
                    currentGameLabel = gameElem;
                    break;
                }
            }

            if (_turnCounter != 0)
            {

                if (_turnCounter % 2 == 0 && currentGameLabel.Row == _currentRow ||
                    _turnCounter % 2 != 0 && currentGameLabel.Column == _currentColumn)
                {
                    _score += tempScore * (_turnCounter % 2 == 0 ? 1 : -1);
                    _currentColumn = currentGameLabel.Column;
                    _currentRow = currentGameLabel.Row;

                    _turnCounter++;
                    (sender as Label).Visible = false;
                }
                else return;
                
                labelScore.Text = "Score: " + _score.ToString();
                labelColumn.Text = "Column: " + _currentColumn;
                labelRow.Text = "Row: " + _currentRow;
            }
            else
            {

                _score += tempScore * (_turnCounter % 2 == 0 ? 1 : -1);
                _turnCounter++;
                _currentRow = currentGameLabel.Row;
                _currentColumn = currentGameLabel.Column;

                labelScore.Text = "Score: " + _score.ToString();
                labelColumn.Text = "Column: " + _currentColumn;
                labelRow.Text = "Row: " + _currentRow;

                (sender as Label).Visible = false;
            }


        }
    }
}
