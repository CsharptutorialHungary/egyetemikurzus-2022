using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class GameConfig
    {
        public GameConfig(string _GameName)
        {
            this._GameName = _GameName;

            int[] step1 = { 0, 1, 2 };
            int[] step2 = { 3, 4, 5 };
            int[] step3 = { 6, 7, 8 };
            int[] step4 = { 0, 3, 6 };
            int[] step5 = { 1, 4, 7 };
            int[] step6 = { 2, 5, 8 };
            int[] step7 = { 0, 4, 8 };
            int[] step8 = { 2, 4, 6 };
            this._WinSteps = new List<int[]>() { step1, step2, step3, step4, step5, step6, step7, step8 };
        }

        private readonly string _GameName;

        public string GameName
        {
            get { return _GameName; }
        }

        private readonly List<int[]> _WinSteps;

        public List<int[]> WinSteps
        {
            get { return _WinSteps; }
        }
    }
}
