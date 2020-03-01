using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maxit_Single_Player
{
    public class GameLabel : Label
    {
        readonly private int _row, _column;
        public int Row { get => _row; }
        public int Column { get => _column; }

        public Label Label { get; set; }
        
        public GameLabel() : base()
        {

        }
        public GameLabel(int row, int column, Label label) : base()
        {
            Label = label;
            _row = row;
            _column = column;
        }
    }
}
