using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterHelper
{
    internal class Chapter
    {
        /// <summary>
        /// チャプターのタイトルを取得/設定します。
        /// </summary>
        public string? Title
        {
            get;
            set;
        }

        /// <summary>
        /// チャプターの開始時間を取得/設定します。
        /// </summary>
        public int Start
        {
            get;
            set;
        }

        /// <summary>
        /// チャプターの終了時間を取得/設定します。
        /// </summary>
        public int End
        {
            get;
            set;
        }
    }
}
